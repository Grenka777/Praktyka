using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
namespace Kryptografy
{
    public partial class Form1 : Form
    {
        readonly CspParameters cspp = new CspParameters();
        RSACryptoServiceProvider _rsa;
        const string EncrFolder = @"d:\Encrypt\";
        const string DecrFolder = @"d:\Decrypt\";
        const string Srcfolder = @"d:\docs\";

        const string PubKeyFile = @"d:\encrypt\rsaPublicKey.txt";

        const string KeyName = "Key01";

        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cspp.KeyContainerName = KeyName;
            _rsa = new RSACryptoServiceProvider(cspp)
            {
                PersistKeyInCsp = true
            };
            label1.Text = _rsa.PublicOnly
             ? $"Key: {cspp.KeyContainerName} - Public Only"
              : $"Key: {cspp.KeyContainerName} - Full Key Pair";
        }

        private void buttonCreateAsmKeys_Click(object sender, EventArgs e)
        {
            cspp.KeyContainerName = KeyName;
            _rsa = new RSACryptoServiceProvider(cspp)
            {
                PersistKeyInCsp = true
            };

            label1.Text = _rsa.PublicOnly
                ? $"Key: {cspp.KeyContainerName} - Public Only"
                : $"Key: {cspp.KeyContainerName} - Full key Pair";
        }

        private void buttonEncryptFile_Click(object sender, EventArgs e)
        {
            if (_rsa is null)
            {
                MessageBox.Show("Key not set");
            }
            else
            {
                _encryptOpenFileDialog.InitialDirectory = Srcfolder;
                if (_encryptOpenFileDialog.ShowDialog()==DialogResult.OK)
                {
                    string fName = _encryptOpenFileDialog.FileName;
                    if (fName!=null)
                    {
                        EncryptFile(new FileInfo(fName));
                    }
                }
            }
        }
        private void EncryptFile(FileInfo file)
        {
            Aes aes = Aes.Create();
            ICryptoTransform transform = aes.CreateEncryptor();


            byte[] keyEncrypted = _rsa.Encrypt(aes.Key, false);

            int lKey = keyEncrypted.Length;
            byte[] LenK = BitConverter.GetBytes(lKey);
            int lIV = aes.IV.Length;
            byte[] LenIV = BitConverter.GetBytes(lIV);


            string outFile = Path.Combine(EncrFolder, Path.ChangeExtension(file.Name, ".enc"));

            using (var OutFs = new FileStream(outFile, FileMode.Create))
            {
                OutFs.Write(LenK, 0, 4);
                OutFs.Write(LenIV, 0, 4);
                OutFs.Write(keyEncrypted, 0, lKey);
                OutFs.Write(aes.IV, 0, lIV);

                using(var outStreamEncrypted = new CryptoStream(OutFs, transform, CryptoStreamMode.Write))
                {
                    int count = 0;
                    int offset = 0;

                    int blockSizeBytes = aes.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];
                    int bytesRead = 0;

                    using (var inFs = new FileStream(file.FullName, FileMode.Open))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamEncrypted.Write(data, 0, count);
                            bytesRead += blockSizeBytes;
                        } while (count > 0);
                    }
                    outStreamEncrypted.FlushFinalBlock();
                }

            }
        }

        private void buttonDecryptFile_Click(object sender, EventArgs e)
        {
            if (_rsa is null)
            {
                MessageBox.Show("Key not set.");
            }
            else
            {
                // Display a dialog box to select the encrypted file.
                _decryptOpenFileDialog.InitialDirectory = EncrFolder;
                if (_decryptOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fName = _decryptOpenFileDialog.FileName;
                    if (fName != null)
                    {
                        DecryptFile(new FileInfo(fName));
                    }
                }
            }
        }


        private void DecryptFile(FileInfo file)
        {
            // Create instance of Aes for
            // symmetric decryption of the data.
            Aes aes = Aes.Create();

            // Create byte arrays to get the length of
            // the encrypted key and IV.
            // These values were stored as 4 bytes each
            // at the beginning of the encrypted package.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            // Construct the file name for the decrypted file.
            string outFile =
                Path.ChangeExtension(file.FullName.Replace("Encrypt", "Decrypt"), ".txt");

            // Use FileStream objects to read the encrypted
            // file (inFs) and save the decrypted file (outFs).
            using (var inFs = new FileStream(file.FullName, FileMode.Open))
            {
                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Read(LenK, 0, 3);
                inFs.Seek(4, SeekOrigin.Begin);
                inFs.Read(LenIV, 0, 3);

                // Convert the lengths to integer values.
                int lenK = BitConverter.ToInt32(LenK, 0);
                int lenIV = BitConverter.ToInt32(LenIV, 0);

                // Determine the start postition of
                // the ciphter text (startC)
                // and its length(lenC).
                int startC = lenK + lenIV + 8;
                int lenC = (int)inFs.Length - startC;

                // Create the byte arrays for
                // the encrypted Aes key,
                // the IV, and the cipher text.
                byte[] KeyEncrypted = new byte[lenK];
                byte[] IV = new byte[lenIV];

                // Extract the key and IV
                // starting from index 8
                // after the length values.
                inFs.Seek(8, SeekOrigin.Begin);
                inFs.Read(KeyEncrypted, 0, lenK);
                inFs.Seek(8 + lenK, SeekOrigin.Begin);
                inFs.Read(IV, 0, lenIV);

                Directory.CreateDirectory(DecrFolder);
                // Use RSACryptoServiceProvider
                // to decrypt the AES key.
                byte[] KeyDecrypted = _rsa.Decrypt(KeyEncrypted, false);

                // Decrypt the key.
                ICryptoTransform transform = aes.CreateDecryptor(KeyDecrypted, IV);

                // Decrypt the cipher text from
                // from the FileSteam of the encrypted
                // file (inFs) into the FileStream
                // for the decrypted file (outFs).
                using (var outFs = new FileStream(outFile, FileMode.Create))
                {
                    int count = 0;
                    int offset = 0;

                    // blockSizeBytes can be any arbitrary size.
                    int blockSizeBytes = aes.BlockSize / 8;
                    byte[] data = new byte[blockSizeBytes];

                    // By decrypting a chunk a time,
                    // you can save memory and
                    // accommodate large files.

                    // Start at the beginning
                    // of the cipher text.
                    inFs.Seek(startC, SeekOrigin.Begin);
                    using (var outStreamDecrypted =
                        new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        do
                        {
                            count = inFs.Read(data, 0, blockSizeBytes);
                            offset += count;
                            outStreamDecrypted.Write(data, 0, count);
                        } while (count > 0);

                        outStreamDecrypted.FlushFinalBlock();
                    }
                }
            }
        }

        private void buttonExportPublicKey_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(EncrFolder);
            using (var sw = new StreamWriter(PubKeyFile, false))
            {
                sw.Write(_rsa.ToXmlString(false));
            }
        }

        private void buttonimportPublicKey_Click(object sender, EventArgs e)
        {
            using (var sr = new StreamReader(PubKeyFile))
            {
                cspp.KeyContainerName = KeyName;
                _rsa = new RSACryptoServiceProvider(cspp);

                string keytxt = sr.ReadToEnd();
                _rsa.FromXmlString(keytxt);
                _rsa.PersistKeyInCsp = true;

                label1.Text = _rsa.PublicOnly
                    ? $"Key: {cspp.KeyContainerName } - Public Only"
                :$"Key: {cspp.KeyContainerName } - Full Key Pair";
            }
        }
    }
}

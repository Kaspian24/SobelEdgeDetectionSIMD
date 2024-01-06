namespace JaZespol3WinForms
{
    public partial class Form1 : Form
    {
        Bitmap? original;
        Bitmap? result;
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            if (original == null)
            {
                MessageBox.Show("Choose image first", "error");
                return;
            }
            int detectionLevelSquared;
            try
            {
                detectionLevelSquared = int.Parse(textBox2.Text);
                detectionLevelSquared *= detectionLevelSquared;
            }
            catch (FormatException)
            {
                MessageBox.Show("Input integer as Detection level", "error");
                return;
            }

            ButtonRun.Enabled = false;

            result = (Bitmap)original.Clone();

            // Lock the bitmap's bits.
            Rectangle rect = new(0, 0, result.Width, result.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                result.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                result.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * result.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Create helper array
            byte[] grayValues = new byte[result.Width * result.Height * 3];

            string method = "Cpp";
            System.Diagnostics.Stopwatch watch;

            // Choose method (Asm or Cpp), start timer, call chosen method and stop timer
            if (checkBox1.Checked)
            {
                watch = System.Diagnostics.Stopwatch.StartNew();
                _ = Program.SobelAsm(rgbValues, grayValues, result.Width, result.Height, Math.Abs(bmpData.Stride), detectionLevelSquared);
                watch.Stop();
                method = "Asm";
            }
            else
            {
                watch = System.Diagnostics.Stopwatch.StartNew();
                _ = Program.SobelCpp(rgbValues, grayValues, result.Width, result.Height, Math.Abs(bmpData.Stride), detectionLevelSquared);
                watch.Stop();
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            result.UnlockBits(bmpData);

            label1.Text = watch.Elapsed.ToString(@"m\:ss\.fff") + " (" + method + ")";
            pictureBox2.Image = (Image)result;

            ButtonRun.Enabled = true;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            // Show OpenFileDialog
            using OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\resources\"));
            openFileDialog.Filter = "bmp files (*.bmp)|*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a new bitmap.
                    original = new Bitmap(openFileDialog.FileName);
                    if (original.Width < 3 || original.Height < 3)
                    {
                        MessageBox.Show("Image too small", "error");
                        return;
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found", "error");
                    return;
                }
                catch (System.ArgumentException)
                {
                    MessageBox.Show("Cannot load file as bitmap", "error");
                    return;
                }
                pictureBox2.Image = null;
                pictureBox1.Image = (Image)original;
            }
        }
    }
}
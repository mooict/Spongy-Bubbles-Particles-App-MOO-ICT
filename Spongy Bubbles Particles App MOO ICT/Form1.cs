namespace Spongy_Bubbles_Particles_App_MOO_ICT
{
    // Made by MOO ICT
    // For educational purpose only
    public partial class Form1 : Form
    {

        List<Bubble> BubbleList = new List<Bubble>();
        string[] backgrounds = { "01.jpg", "02.jpg", "03.jpg", "04.jpg", "05.jpg" };

        int backgroundNumber = 1;
        Random random = new Random();
        Image background;


        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            background = Image.FromFile("images/" + backgrounds[backgroundNumber]);
            //this.BackgroundImage = background;
            //this.BackgroundImageLayout = ImageLayout.Stretch;

            MakeBubbles();
        }

        private void ParticlesTimerEvent(object sender, EventArgs e)
        {
            foreach (Bubble tempBubble in BubbleList)
            {
                tempBubble.MoveBubble();
                tempBubble.posY -= tempBubble.speedY;
                tempBubble.posX += tempBubble.speedX;

                if (tempBubble.posY < tempBubble.topLimit)
                {
                    tempBubble.posY = 700;
                    tempBubble.posX = random.Next(0, 800);
                }
            }

            this.Invalidate();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                backgroundNumber += 1;

                if (backgroundNumber > backgrounds.Length  -1)
                {
                    backgroundNumber = 0;
                }

                background = Image.FromFile("images/" + backgrounds[backgroundNumber]);
                //this.BackgroundImage = background;
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;

            Canvas.DrawImage(background, 0, 0, 800, 500);

            foreach (Bubble tempBubble  in BubbleList)
            {
                Canvas.DrawImage(tempBubble.bubble, tempBubble.posX, tempBubble.posY, tempBubble.width, tempBubble.height);
            }
        }

        private void MakeBubbles()
        {
            for (int i = 0; i < 300; i++)
            {
                Bubble newBubble = new Bubble();
                BubbleList.Add(newBubble);
            }
        }
    }
}
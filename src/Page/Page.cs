namespace Beta3.Page
{
    using Terminal.Gui;

    public class Page : Window
    {
        protected ColorScheme redOnBlack;
        protected ColorScheme whiteOnBlack;
        protected ColorScheme buttonScheme;

        public Page()
        {
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Border.BorderStyle = BorderStyle.None;
            this.ColorScheme.Normal = new Attribute(Color.Black, Color.Black);

            redOnBlack = new ColorScheme()
            {
                Normal = new Attribute(Color.BrightMagenta, Color.Black),
                HotNormal = new Attribute(Color.BrightMagenta, Color.Black),
                Focus = new Attribute(Color.BrightMagenta, Color.Black),
                HotFocus = new Attribute(Color.BrightMagenta, Color.Black),
            };

            whiteOnBlack = new ColorScheme()
            {
                Normal = new Attribute(Color.White, Color.Black),
                HotNormal = new Attribute(Color.White, Color.Black),
                Focus = new Attribute(Color.White, Color.Black),
                HotFocus = new Attribute(Color.White, Color.Black),
            };

            buttonScheme = new ColorScheme()
            {
                Normal = new Attribute(Color.White, Color.Black),
                HotNormal = new Attribute(Color.White, Color.Black),
                Focus = new Attribute(Color.White, Color.Magenta),
                HotFocus = new Attribute(Color.White, Color.Magenta),
            };
        }
    }
}

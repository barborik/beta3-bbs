using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Board : Page
    {
        private View threadForm;
        private Label titleLabel;
        private Label contentLabel;
        private TextField titleField;
        private TextView contentField;
        private Button postButton;

        private void InitViews()
        {
            threadForm = new View()
            {
                X = Pos.Center(),
                Y = 1,
                Width = 46,
                Height = 13,
                Border = new Border()
                {
                    Title = "Start a New Thread",
                    BorderStyle = BorderStyle.Single,
                },
                ColorScheme = whiteOnBlack,
            };

            titleLabel = new Label()
            {
                X = 3,
                Y = 1,
                Text = "Title",
            };

            contentLabel = new Label()
            {
                X = 3,
                Y = 4,
                Text = "Content",
            };

            titleField = new TextField()
            {
                X = 3,
                Y = 2,
                Width = 40,
                Height = 1,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                    Focus = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                },
            };

            contentField = new TextView()
            {
                X = 3,
                Y = 5,
                Width = 40,
                Height = 6,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                    Focus = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                },
                WordWrap = true,
                AllowsTab = false,
            };

            postButton = new Button()
            {
                X = 3,
                Y = 12,
                Width = 4,
                Height = 1,
                Text = "Post",
                ColorScheme = buttonScheme,
            };

            this.Add(threadForm);
            threadForm.Add(titleLabel);
            threadForm.Add(titleField);
            threadForm.Add(contentLabel);
            threadForm.Add(contentField);
            threadForm.Add(postButton);
        }
    }
}

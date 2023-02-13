using Terminal.Gui;

namespace Beta3.Page
{
    public partial class SysopMenu : Page
    {
        private View banForm;
        private TextField banUsername;
        private TextView banReason;
        private DateField banEnd;
        private Button banButton;
        private Label banUserLabel;
        private Label banReasonLabel;
        private Label banEndLabel;

        private View promoteForm;
        private Label promoteUserLabel;
        private Label promoteBoardLabel;
        private TextField promoteUserField;
        private TextField promoteBoardField;
        private Button promoteButton;

        private void InitViews()
        {
            // BAN FORM
            banForm = new View()
            {
                X = 1,
                Y = 1,
                Width = 46,
                Height = 13,
                Border = new Border()
                {
                    Title = "Ban a User",
                    BorderStyle = BorderStyle.Single,
                },
                ColorScheme = whiteOnBlack,
            };

            banUserLabel = new Label()
            {
                X = 3,
                Y = 1,
                Text = "Username",
            };

            banReasonLabel = new Label()
            {
                X = 3,
                Y = 4,
                Text = "Reason",
            };

            banEndLabel = new Label()
            {
                X = 3,
                Y = 9,
                Text = "End",
            };

            banUsername = new TextField()
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

            banReason = new TextView()
            {
                X = 3,
                Y = 5,
                Width = 40,
                Height = 3,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                    Focus = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                },
                WordWrap = true,
                AllowsTab = false,
            };

            banEnd = new DateField()
            {
                X = 3,
                Y = 10,
                Width = 12,
                Height = 1,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                    Focus = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                },
            };

            banButton = new Button()
            {
                X = 3,
                Y = 12,
                Width = 4,
                Height = 1,
                Text = "Ban",
                ColorScheme = buttonScheme,
            };

            this.Add(banForm);
            banForm.Add(banReasonLabel);
            banForm.Add(banUserLabel);
            banForm.Add(banEndLabel);
            banForm.Add(banUsername);
            banForm.Add(banReason);
            banForm.Add(banEnd);
            banForm.Add(banButton);

            // PROMOTE FORM
            promoteForm = new View()
            {
                X = Application.Top.Bounds.Right - 49,
                Y = 1,
                Width = 46,
                Height = 13,
                Border = new Border()
                {
                    Title = "Promote a User",
                    BorderStyle = BorderStyle.Single,
                },
                ColorScheme = whiteOnBlack,
            };

            promoteUserLabel = new Label()
            {
                X = 3,
                Y = 1,
                Text = "Username",
            };

            promoteBoardLabel = new Label()
            {
                X = 3,
                Y = 4,
                Text = "Board",
            };

            promoteUserField = new TextField()
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

            promoteBoardField = new TextField()
            {
                X = 3,
                Y = 5,
                Width = 40,
                Height = 1,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                    Focus = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                },
            };

            promoteButton = new Button()
            {
                X = 3,
                Y = 12,
                Width = 4,
                Height = 1,
                Text = "Promote",
                ColorScheme = buttonScheme,
            };

            this.Add(promoteForm);
            promoteForm.Add(promoteUserLabel);
            promoteForm.Add(promoteBoardLabel);
            promoteForm.Add(promoteUserField);
            promoteForm.Add(promoteBoardField);
            promoteForm.Add(promoteButton);
        }
    }
}

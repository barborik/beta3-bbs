using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Messages : Page
    {
        private ScrollView container;

        private View messageForm;
        private TextView messageField;
        private Button sendButton;

        private void InitViews()
        {
            int height = 0;

            container = new ScrollView()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 10,
                ColorScheme = whiteOnBlack,
                ContentOffset = new Point()
                {
                    X = 0,
                    Y = 0,
                },
            };

            List<Entity.Message> messages = Beta3Context.Context.Message
            .Where(m => m.ReceiverID == Home.user.ID).Where(m => m.SenderID == this.from.ID)
            .Concat(Beta3Context.Context.Message
            .Where(m => m.SenderID == Home.user.ID).Where(m => m.ReceiverID == this.from.ID))
            .OrderBy(m => m.Sent).ToList();

            foreach (Entity.Message message in messages)
            {
                View postView = new View()
                {
                    X = 2,
                    Y = height + 1,
                    Width = Dim.Fill() - 4,
                    Height = message.Content.Length / Application.Top.Bounds.Right + 3,
                    Text = "\n  " + message.Content + "  \n",
                    ColorScheme = whiteOnBlack,
                    Border = new Border()
                    {
                        Title = String.Format("{0} - {1}",
                        Beta3Context.Context.User.Where(u => u.ID == message.SenderID).First().Username,
                        message.Sent.ToString("dd/MM/yyyy HH:mm")),
                        BorderStyle = BorderStyle.Rounded,
                        BorderBrush = Color.DarkGray,
                    }
                };

                height += message.Content.Length / Application.Top.Bounds.Right + 6;
                container.Add(postView);
            }

            container.ContentSize = new Size()
            {
                Width = Application.Top.Bounds.Right - 3,//this.Bounds.Right,
                Height = height,
            };

            this.Add(container);

            // FORM
            messageForm = new View()
            {
                X = Pos.Center(),
                Y = Application.Top.Bounds.Bottom - 10,
                Width = 44,
                Height = 7,
                ColorScheme = redOnBlack,
                Border = new Border()
                {
                    BorderStyle = BorderStyle.Single,
                }
            };

            messageField = new TextView()
            {
                X = Pos.Center(),
                Y = 0,
                Width = 42,
                Height = 5,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                    Focus = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                },
                AllowsTab = false,
            };

            sendButton = new Button()
            {
                X = Pos.Center(),
                Y = 6,
                Width = 10,
                Height = 1,
                Text = "Post",
                ColorScheme = buttonScheme,
            };

            messageForm.Add(messageField);
            messageForm.Add(sendButton);
            this.Add(messageForm);
        }
    }
}

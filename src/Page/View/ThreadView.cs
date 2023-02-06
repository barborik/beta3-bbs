using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Thread : Page
    {
        private ScrollView container;

        private View postForm;
        private TextView postField;
        private Button postButton;


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

            List<Entity.Post> posts = Beta3Context.Context.Post
            .Where(p => p.ThreadID == thread.ID)
            .OrderBy(p => p.Created).ToList();

            foreach (Entity.Post post in posts)
            {
                View postView = new View()
                {
                    X = 2,
                    Y = height + 1,
                    Width = Dim.Fill() - 4,
                    Height = post.Content.Length / Application.Top.Bounds.Right + 3,
                    Text = "\n  " + post.Content + "  \n",
                    ColorScheme = whiteOnBlack,
                    Border = new Border()
                    {
                        Title = String.Format("{0} - {1}",
                        Beta3Context.Context.User.Where(u => u.ID == post.UserID).First().Username,
                        post.Created.ToString("dd/MM/yyyy HH:mm")),
                        BorderStyle = BorderStyle.Rounded,
                        BorderBrush = Color.DarkGray,
                    }
                };

                height += post.Content.Length / Application.Top.Bounds.Right + 6;
                container.Add(postView);
            }

            container.ContentSize = new Size()
            {
                Width = Application.Top.Bounds.Right - 3,//this.Bounds.Right,
                Height = height,
            };

            this.Add(container);

            // FORM
            postForm = new View()
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

            postField = new TextView()
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

            postButton = new Button()
            {
                X = Pos.Center(),
                Y = 6,
                Width = 10,
                Height = 1,
                Text = "Post",
                ColorScheme = buttonScheme,
            };

            postForm.Add(postField);
            postForm.Add(postButton);
            this.Add(postForm);
        }
    }
}

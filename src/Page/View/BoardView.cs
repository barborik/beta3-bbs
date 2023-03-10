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

        private View next;
        private View prev;
        private View threads;

        private int page;
        private List<Entity.Thread> threadsList;

        private int width, height, perPage;

        private string ThreadsListString()
        {
            char c = 'A';
            string text = "";

            width = 0;
            height = 0;

            threadsList.Clear();

            perPage = Application.Top.Bounds.Bottom - 22;
            if (perPage > 'Z' - 'A' + 1)
            {
                perPage = 'Z' - 'A' + 1;
            }

            threads.RemoveAll();

            for (int i = 0; i < perPage; i++)
            {
                Entity.Thread thread;
                try
                {
                    thread = Beta3Context.Context.Thread
                    .Where(t => t.BoardID == board.ID).ToList()[page * perPage + i];
                }
                catch
                {
                    continue;
                }

                string listing = String.Format("[{0}] {1}\n", c, thread.Title);
                text += listing;

                threadsList.Add(thread);

                View select = new View()
                {
                    Text = c.ToString(),
                    X = 1,
                    Y = i,
                    Width = 1,
                    Height = 1,
                    ColorScheme = redOnBlack,
                };
                threads.Add(select);

                if (listing.Length > width)
                {
                    width = listing.Length;
                }
                height++;
                c++;
            }

            return text;
        }

        private void InitViews()
        {
            // LIST
            prev = new View()
            {
                X = Pos.Center() - 16,
                Y = Pos.Bottom(this) - 4,
                Width = 16,
                Height = 2,
                Text = "??? [Page Up]",
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
            };

            next = new View()
            {
                X = Pos.Center() + 0,
                Y = Pos.Bottom(this) - 4,
                Width = 16,
                Height = 2,
                Text = "[Page Down] ???",
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
            };

            threads = new View()
            {
                Y = 16,
                TextAlignment = TextAlignment.Left,
                CanFocus = true,
                ColorScheme = whiteOnBlack,
            };
            threads.Text = ThreadsListString();
            threads.X = Pos.Center() - width / 2;
            threads.Width = width;
            threads.Height = height;

            this.Add(next);
            this.Add(prev);
            this.Add(threads);

            // THREAD FORM
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

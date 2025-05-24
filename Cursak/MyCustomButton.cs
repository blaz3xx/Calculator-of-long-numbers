using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomButton
{
    /// <summary>
    /// Представляє кастомну кнопку з можливістю налаштування заокруглених кутів та рамки.
    /// Успадковує функціональність стандартного класу <see cref="Button"/>.
    /// </summary>
    class MyOwnButton : Button
    {
        // --- ІДЕНТИФІКАТОРИ (ЗМІННІ) ---

        /// <summary>
        /// Товщина рамки кнопки в пікселях.
        /// Тип даних: int.
        /// </summary>
        private int borderSize = 0;

        /// <summary>
        /// Радіус заокруглення кутів кнопки в пікселях.
        /// Тип даних: int.
        /// </summary>
        private int borderRadius = 50;

        /// <summary>
        /// Колір рамки кнопки.
        /// Тип даних: Color.
        /// </summary>
        private Color borderColor = Color.DodgerBlue;

        // --- ВЛАСТИВОСТІ ---

        /// <summary>
        /// Отримує або встановлює товщину рамки кнопки.
        /// При встановленні нового значення кнопка перемальовується.
        /// </summary>
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Отримує або встановлює радіус заокруглення кутів.
        /// Значення не може перевищувати висоту кнопки.
        /// </summary>
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = (value <= Height) ? value : Height;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Отримує або встановлює колір фону кнопки.
        /// Є обгорткою для властивості <see cref="Button.BackColor"/>.
        /// </summary>
        public Color BackgroundColor
        {
            get => BackColor;
            set { BackColor = value; }
        }

        /// <summary>
        /// Отримує або встановлює колір тексту кнопки.
        /// Є обгорткою для властивості <see cref="Button.ForeColor"/>.
        /// </summary>
        public Color TextColor
        {
            get => ForeColor;
            set { ForeColor = value; }
        }

        // --- КОНСТРУКТОР ---

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="MyOwnButton"/>
        /// зі стандартними налаштуваннями зовнішнього вигляду.
        /// </summary>
        public MyOwnButton()
        {
            Size = new Size(200, 100);
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.DodgerBlue;
            ForeColor = Color.White;

            Resize += new EventHandler(Button_Resize);
        }

        // --- МЕТОДИ ---

        /// <summary>
        /// Обробник події зміни розміру кнопки. Коригує радіус заокруглення,
        /// якщо він перевищує нову висоту кнопки.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > Height)
            {
                borderRadius = Height;
            }
        }

        /// <summary>
        /// Створює графічний шлях (GraphicsPath) у формі прямокутника із заокругленими кутами.
        /// </summary>
        /// <param name="rectangle">Прямокутник, для якого створюється шлях.</param>
        /// <param name="radius">Радіус заокруглення кутів.</param>
        /// <returns>Об'єкт <see cref="GraphicsPath"/> із заокругленою фігурою.</returns>
        private GraphicsPath GetFigurePath(RectangleF rectangle, float radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - radius, rectangle.Y + rectangle.Height - radius, radius, radius, 0, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Y + rectangle.Height - radius, radius, radius, 90, 90);
            graphicsPath.CloseFigure();

            return graphicsPath;
        }

        /// <summary>
        /// Перевизначений метод для малювання елемента керування.
        /// Відповідає за кастомний рендеринг кнопки з урахуванням заокруглення та рамки.
        /// </summary>
        /// <param name="pevent">Аргументи події малювання, що містять поверхню для малювання.</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectangleSurface = new RectangleF(0, 0, Width, Height);
            RectangleF rectangleBorder = new RectangleF(1, 1, Width - 0.5F, Height - 1);

            if (borderRadius > 1)
            {
                using (GraphicsPath graphicsPathSurface = GetFigurePath(rectangleSurface, borderRadius))
                using (GraphicsPath graphicsPathBorder = GetFigurePath(rectangleBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    Region = new Region(graphicsPathSurface);
                    pevent.Graphics.DrawPath(penBorder, graphicsPathSurface);

                    if (borderSize >= 1)
                    {
                        pevent.Graphics.DrawPath(penBorder, graphicsPathBorder);
                    }
                }
            }
            else
            {
                Region = new Region(rectangleSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }

        /// <summary>
        /// Викликається при створенні дескриптора елемента керування.
        /// Підписується на подію зміни кольору фону батьківського контейнера.
        /// </summary>
        /// <param name="e">Аргументи події.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        /// <summary>
        /// Обробник події зміни кольору фону батьківського контейнера.
        /// Перемальовує кнопку для уникнення візуальних артефактів, особливо в режимі дизайнера.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                this.Invalidate();
            }
        }
    }
}
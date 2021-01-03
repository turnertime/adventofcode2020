using System;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace AdventOfCode
{

    /// <summary>
    /// A column showing the task description (left aligned).
    /// </summary>
    public sealed class JustifiedTaskDescriptionColumn : ProgressColumn
    {

        public Justify Alignment { get; init; }

        /// <inheritdoc/>
        public override IRenderable Render(RenderContext context, ProgressTask task, TimeSpan deltaTime)
        {
            var text = task.Description.RemoveNewlines()?.Trim();
            return new Markup(text ?? string.Empty)
                .Overflow(Overflow.Ellipsis)
                .Alignment(Alignment);
        }

    }

    /// <summary>
    /// A column showing the elapsed time of a task.
    /// </summary>
    public sealed class ElapsedTimeColumn : ProgressColumn
    {

        /// <summary>
        /// Indicates the format of elapsed <see cref="TimeSpan" />.
        /// </summary>
        public string Format { get; init; }

        /// <summary>
        /// Gets or sets the style of the remaining time text.
        /// </summary>
        private Style Style { get; } = new(Color.Blue);

        /// <inheritdoc/>
        public override IRenderable Render(
            RenderContext context,
            ProgressTask task,
            TimeSpan deltaTime)
        {
            var remaining = task.ElapsedTime;
            if (remaining is null)
            {
                return new Markup("-:--:--");
            }

            return new Text(
                remaining.Value.ToString(this.Format ?? "h\\:mm\\:ss"),
                Style ?? Style.Plain);
        }
    }

}

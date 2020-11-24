// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using SixLabors.ImageSharp.Processing.Extensions.Transforms;
using SixLabors.ImageSharp.Processing.Processors.Transforms;
using Xunit;

namespace SixLabors.ImageSharp.Tests.Processing.Transforms
{
    public class SwizzleTests : BaseImageOperationsExtensionTest
    {
        private struct InvertXAndYSwizzler : ISwizzler
        {
            public Size DestinationSize => new Size(10, 10);

            public void Transform(Point point, out Point newPoint)
                => newPoint = new Point(point.Y, point.X);
        }

        [Fact]
        public void InvertXAndYSwizzlerSetsCorrectSizes()
        {
            int width = 5;
            int height = 10;

            this.operations.Swizzle(default(InvertXAndYSwizzler));
            SwizzleProcessor<InvertXAndYSwizzler> processor = this.Verify<SwizzleProcessor<InvertXAndYSwizzler>>();

            Assert.Equal(processor.Swizzler.DestinationSize.Width, height);
            Assert.Equal(processor.Swizzler.DestinationSize.Height, width);

            this.operations.Swizzle(default(InvertXAndYSwizzler));
            SwizzleProcessor<InvertXAndYSwizzler> processor2 = this.Verify<SwizzleProcessor<InvertXAndYSwizzler>>(1);

            Assert.Equal(processor2.Swizzler.DestinationSize.Width, width);
            Assert.Equal(processor2.Swizzler.DestinationSize.Height, height);
        }
    }
}

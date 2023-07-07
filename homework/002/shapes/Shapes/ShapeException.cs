// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace shapes.Shapes
{
    public class InvalidShapeException : Exception { }

    public class InvalidTriangleException : InvalidShapeException { }

    public class InvalidSquareException : InvalidShapeException { }

    public class InvalidCircleException : InvalidShapeException { }
}

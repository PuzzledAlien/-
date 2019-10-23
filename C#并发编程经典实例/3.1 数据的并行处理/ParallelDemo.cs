void RotateMatrices(IEnumerable<Matrix> matrices, float degrees)
{
    Parallel.ForEach(matrices, matrix => matrix.Rotate(degrees));
}

void InvertMatrices(IEnumerable<Matrix> matrices)
{
    Parallel.ForEach(matrices, (matrix, state) =>
    {
        if (!matrix.IsInvertible)
            state.Stop();
        else
            matrix.Invert();
    });
}


void RotateMatrices(IEnumerable<Matrix> matrices, float degrees,
CancellationToken token)
{
    Parallel.ForEach(matrices,
    new ParallelOptions { CancellationToken = token },
    matrix => matrix.Rotate(degrees));
}


// 注意，这不是最高效的实现方式。
// 只是举个例子，说明用锁来保护共享状态。
int InvertMatrices(IEnumerable<Matrix> matrices)
{
    object mutex = new object();
    int nonInvertibleCount = 0;
    Parallel.ForEach(matrices, matrix =>
    {
        if (matrix.IsInvertible)
        {
            matrix.Invert();
        }
        else
        {
            lock (mutex)
            {
                ++nonInvertibleCount;
            }
        }
    });
    return nonInvertibleCount;
}
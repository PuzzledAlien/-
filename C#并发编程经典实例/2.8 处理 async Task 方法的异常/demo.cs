static async Task ThrowExceptionAsync()
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    throw new InvalidOperationException("Test");
}

static async Task TestAsync()
{
    try
    {
        await ThrowExceptionAsync();
    }
    catch (InvalidOperationException) { }
}

static async Task TestAsync()
{
    // 抛出异常并将其存储在 Task 中。
    Task task = ThrowExceptionAsync();
    try
    {
        // Task 对象被 await 调用，异常在这里再次被引发。
        await task;
    }
    catch (InvalidOperationException)
    {
        // 这里，异常被正确地捕获。
    }
}
# Working with Strings

When working with strings, look to Microsoft documentation on the [String Class](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2).
## Remarks
> A string is a sequential collection of characters that is used to represent text. A String object is a sequential collection of [System.Char](https://docs.microsoft.com/en-us/dotnet/api/system.char?view=netframework-4.7.2) objects that represent a string; a System.Char object corresponds to a UTF-16 code unit. The value of the String object is the content of the sequential collection of System.Char objects, and that value is immutable (that is, it is read-only). For more information about the immutability of strings, see the Immutability and the [StringBuilder class](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.7.2) section later in this topic. The maximum size of a String object in memory is 2GB, or about 1 billion characters.
> 

### Rolling your own methods
---
The String class has many methods and properties yet there will be times when a developer will need to write methods for task when a method is not in the String Class.

Example for the Contains method.
The string.Contains() method in C# is case sensitive. And there is not [StringComparison](https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparison?view=netframework-4.7.2) parameter available similar to [Equals() method](https://docs.microsoft.com/en-us/dotnet/api/system.string.equals?view=netframework-4.7.2), which helps to compare case insensitive.

If you run the following tests, TestStringContains2() will fail.
```csharp
[TestMethod]
public void TestStringContains()
{
    var text = "This is a sample string";
    Assert.IsTrue(text.Contains("sample"));
}

[TestMethod]
public void TestStringContains2()
{
    var text = "This is a sample string";
    Assert.IsTrue(text.Contains("Sample"));
}
```

Other option is using like this.
```csharp
Assert.IsTrue(text.ToUpper().Contains("Sample".ToUpper()));
```

And here is the case insensitive contains method implementation.

```csharp
public static class Extensions
{
    public static bool CaseInsensitiveContains(this string text, string value, 
        StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
    {
        return text.IndexOf(value, stringComparison) >= 0;
    }
}
```

And here is the modified tests.

```csharp
[TestMethod]
public void TestStringContains()
{
    var text = "This is a sample string";
    Assert.IsTrue(text.CaseInsensitiveContains("sample"));
}

[TestMethod]
public void TestStringContains2()
{
    var text = "This is a sample string";
    Assert.IsTrue(text.CaseInsensitiveContains("Sample"));
}
```

### Extension methods for strings
---
Extension methods for strings should be placed into a static class either in your current project or in the base library.

The [following page](https://github.com/karenpayneoregon/LanguageExtensions/blob/master/ExtensionsLibrary/StringExtensions.cs) has several common extension methods for strings.

***TIP***
---
A method in the string class like [string.IsNullOrWhiteSpace](https://docs.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace?view=netframework-4.7.2) can be made to work like a method.

```csharp
/// <summary>
/// Determine if string is empty
/// </summary>
/// <param name="sender">String to test if null or whitespace</param>
/// <returns>true if empty or false if not empty</returns>
public static bool IsNullOrWhiteSpace(this string sender)
{
    return string.IsNullOrWhiteSpace(sender);
}
```

[Back to main page](https://github.com/karenpayneoregon/VisualStudioEducation).
# Getting started with Microsoft Visual Studio 2017+ and C#

The intent for this repository is to introduce seasoned developers in any major language such as JavaScript, Cold Fusion or Visual Basic to the following.
- C# programming language basics.
- Navigating Visual Studio's IDE.

Good links to get started with
- [Visual Studio Documentation](https://docs.microsoft.com/en-us/visualstudio/?view=vs-2019) (very informative and lengthy)
- [Learning the code editor](https://docs.microsoft.com/en-us/visualstudio/get-started/tutorial-editor?view=vs-2019) in Visual Studio.

By following what is presented will assist developers when training becomes available here by a vendor.

## C# 7 (or higher) programming language 
> While working with code many of the code samples will show old school methods to accomplish a task then a secondary example will show current conventions while discussing alternates hybrid solutions. Alternate and hybrid solutions are intermediate level ways to complete a task, which in many cases does not hinder performance. 

Example: The task is to display a person's first and last name.
```csharp
static void OldSchool()
{
    string firstName = "Karen";
    string lastName = "Payne";

    Console.WriteLine(firstName + " " + lastName);
}
```

The above code block works but there is a best practice for writing this today.

```csharp
var firstName = "Karen";
var lastName = "Payne";

Console.WriteLine($"{firstName} {lastName}");
```

## Visual Studio
"How to" in Visual Studio will be broken down into separate pages within this repository to perform common task.

- Visual Studio [general topics](https://github.com/karenpayneoregon/VisualStudioEducation/blob/master/VisualStudio/VisualStudioShortcuts.md).


## C# Basics
The following section provides basics for getting started with C# programming language.
- [Working with strings](https://github.com/karenpayneoregon/VisualStudioEducation/tree/master/LessonsDocumentation/StringType/Strings.md) 
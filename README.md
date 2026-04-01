# Training on C#

#### Computing: A machine that takes decisions based on the inputs given by the User.
- To do that decisions making, we need programs. Machines understand only binary inputs. To handle them, we depend on Programming languages. 
- First high level languages like Fortran and Cobol were used in the scientific and Banking industry respectively. (Mid 50s and 60s)

#### Structural Programming languages 
- C (1972), SQL(1974)... Functions become popular with these languages. 
- U could create custom datatypes like Structures to store multiple sets of data as one unit. 

#### Object Oriented Programming: 
- C++ was C with OOP features, making it one of the most powerful languages in the Computing world. Developed in 1983. 
- Perl : Basically on Unix machines for system administration support and first web development environments.

#### Internet and Scripting Era:(1990s)
1. Python : Good for data sciences and AI. 
2. Java : Write once, run anywhere. They did not have pointers. 
3. Javascipt (1995): Client side script. Developed by Netscape, currently its the main scripting language for all Web computing.   
4. PHP and Ruby : Server side development. 

#### Modren era : 
- C# (2001) , Swift programming languages came up. Developed by MS for creating Windows Apps. Similar to C++ with more cleaner syntax.
  - U need a tool like Visual Studio to develop the code. It is available in multiple editions like Community(Free), Developer (Proprietory).
- Developed by Anders Heilsberg with lots of features of C++ and few features from Java and VB. 

#### Features of C# Language:
1. Object oriented -> Classes and interfaces.
2. Syntax that is easy to learn and implement.
3. Supports automatic memory management using GC(Garbage Collector).
4. Strongly Typed language-> The compiler shall catch most of the errors before the code even executes/runs. it prevents mismatchs of the data. Helpful in speed and conversion related operations.
5. It runs on a platform called .NET(Dotnet) which is masive ecosystem for running various kinds of Apps: Web based, Desktop based, Micro services based and many more. 
 - Current version of C# is 15/16 and the LTS is C# 14.

### What is .NET?
Its a free Open source cross platform developer Platform for building various kinds of Applications.
One Unified system for all kinds of App developement: Web, Mobile, Desktop, Cloud, Gaming as well as AI and Data Analytics. 
It supports multiple languages like C#, VB, Cobol, python, pascal and many more.
Supports AI development using Semantic Kernal which allows developers to create LLMs and manage the agent based workflows with the existing applications. 
<img width="574" height="627" alt="image" src="https://github.com/user-attachments/assets/8928118c-5009-470d-a4ef-3e33aa85cb2e" />
### How does this work?
- Write : U develop the code using your fav language like C#, VB or any langauge of your choice
- Compile: The code that U develop shall be compiled to an Intermediate language(IL).
- Deploy: U package this IL into a DLL (Library) or EXE(App) -> we call in .NET as Assembly. Assembly is the Deployment Unit of .NET.
- Execute: U can execute the EXE Assembly wherever .NET is installed. When the app executes, a JIT compiler in the Environment converts UR IL into specific machine code optimized to execute on that CPU. 
<img width="1080" height="731" alt="image" src="https://github.com/user-attachments/assets/82c6abec-cbac-425d-96b4-37d05f7a1932" />

### How to develop this kind of Apps?
1. Any Text Editor
2. .NET Environment available in every Windows OS since 2005.
3. Commandline tools to help in compiling and building the Apps. 
4. Best option is an tool called Visual Studio.  It is an IDE(Integrated Development Environment). 
U can download the community edition for learning purposes. https://visualstudio.microsoft.com/downloads/

For development purposes, you shall obtain licences for the Visual Studio and consume it. Developer Edition and Professional Edition which have enhanced features like Project maintainence, Collaborative support, Analytic support and many visual components like Code Analyzer, SQL Command Builders and many more. 

-Visual Studio -> New Project -> Console App (.NET Framework).
- Allows to: 
- Give a name to the Project. (Files will be created as csproj)
- Solution Name -> Group of Projects( FIle shall be created as .sln)
- Location of the Soln/Project
- The Version of the .NET Framework. 

#### Namespace: 
1. Conceptual grouping of code to avoid naming conflicts. U could create 2 components with the same name and seperated by namespace and refer each of them using the namespace name. 
2. Namespace does not have any file as such. It is purely conceptual.
3. By default, every code U develop in the Project shall have the Project name as the default namespace. 

#### class
- Fundamental unit of any C# Application. This represents a program to execute. 
- function called Main(Case sensitive) with static modifier



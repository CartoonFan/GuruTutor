namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("GuruTutor")>]
[<assembly: AssemblyProductAttribute("GuruTutor")>]
[<assembly: AssemblyDescriptionAttribute("This is a redesign and extension of the original Guru project funded by the Institute of Education Sciences from 2008-20edesign incorporates the previous GnuTutor project and represents the next stage of that project. The name change to GuruTutor reflects that the name GnuTutor is no longer appropriate for code that does not use a GPL license.")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"

(*

The following program is entirely my own work, as Phillip Lane.
This program is covered under the CC-BY-SA license.

Test compiled with Visual Studio Community 2017 edition, and passes all test cases under the .sh file provided.

For running on a linux system, make sure some form of mono is installed. :) Thank you for taking a look at this
terrible, terrible program. It's probably the worst thing I've ever made and is so incredibly fragile that I doubt
it would work for this entire comment section.

*)

let str = System.Environment.GetCommandLineArgs().[1] in let forcevowels = [| "xr"; "yt" |] in let consonants = [| "b"; "c"; "ch"; "d"; "f"; "g"; "h"; "j"; "k"; "l"; "m"; "n"; "p"; "ph"; "q"; "qu"; "r"; "s"; "sh"; "t"; "th"; "v"; "w"; "x"; "y"; "z"; "rh"; "thr"; "sch" |] in for i in str.Split(' ') do let word = if i.Length > 2 && Array.exists (fun x -> x = System.Convert.ToString(i.[0]) + System.Convert.ToString(i.[1]) + System.Convert.ToString(i.[2])) consonants then i.Substring 3 + System.Convert.ToString(i.[0]) + System.Convert.ToString(i.[1]) + System.Convert.ToString(i.[2]) + "ay" else if i.Length > 4 && Array.exists (fun x -> x = System.Convert.ToString(i.[0]) + System.Convert.ToString(i.[1]) + System.Convert.ToString(i.[2]) + System.Convert.ToString(i.[3])) (Array.map (fun x -> x + "qu") consonants) then i.Substring 4 + System.Convert.ToString(i.[0]) + System.Convert.ToString(i.[1]) + "quay" else if i.Length > 3 && Array.exists (fun x -> x = System.Convert.ToString(i.[0]) + System.Convert.ToString(i.[1]) + System.Convert.ToString(i.[2])) (Array.map (fun x -> x + "qu") consonants) then i.Substring 3 + System.Convert.ToString(i.[0]) + "quay" else if i.Length > 1 && Array.exists (fun x -> x = System.Convert.ToString(i.[0]) + System.Convert.ToString(i.[1])) forcevowels then i + "ay" else if i.Length > 1 && Array.exists (fun x -> x = System.Convert.ToString(i.[0]) + System.Convert.ToString(i.[1])) consonants then i.Substring 2 + System.Convert.ToString(i.[0]) + System.Convert.ToString(i.[1]) + "ay" else if Array.exists (fun x -> x = System.Convert.ToString(i.[0])) consonants then i.Substring 1 + System.Convert.ToString(i.[0]) + "ay" else i + "ay" in if i = str.Split(' ').[str.Split(' ').Length - 1] then printf "%s" word else printf "%s " word
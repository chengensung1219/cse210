using System;
using System.IO;
class Entry
{   
    List<string> loadEntryList = new List<string>();

    public List<string> loadFile(string filename) {
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            this.loadEntryList.Add(line);
        }
        return loadEntryList;
    }
    
}
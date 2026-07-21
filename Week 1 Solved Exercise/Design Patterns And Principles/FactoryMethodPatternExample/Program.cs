using System;

//Product Interface and subclasses
interface IDocument {
    void open();
}

class WordDocument : IDocument {
    public void open() {
        Console.WriteLine("Opening Word Document");
    }
}
class PdfDocument : IDocument
{
    public void open()
    {
        Console.WriteLine("Opening PDF Document");
    }
}

class ExcelDocument : IDocument
{
    public void open()
    {
        Console.WriteLine("Opening Excel Document");
    }
}

//Factory Interface and Concrete Factories
interface IDocumentFactory {
    IDocument CreateDocument(string type);
}

//Concrete Factory
class DocumentFactory : IDocumentFactory { 
    public IDocument CreateDocument(string type)
    {
        if (type.ToLower() == "word")
        {
            return new WordDocument();
        }
        else if (type.ToLower() == "pdf")
        {
            return new PdfDocument();
        }
        else if (type.ToLower() == "excel")
        {
            return new ExcelDocument();
        }
        else {
            Console.WriteLine("Invalid Document Type");
            return null;
        }
    }
}


//Main class
class Program { 
    static void Main(string[] args){
        string type = "pdf";

        IDocumentFactory factory = new DocumentFactory();

        IDocument document = factory.CreateDocument(type);

        if(document != null)
        {
            document.open();
        }
        
        Console.ReadKey();
    }
}


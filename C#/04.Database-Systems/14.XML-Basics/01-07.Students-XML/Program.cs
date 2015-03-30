namespace _01_07.Students_XML
{
    using System.Xml.Xsl;

    class Program
    {
        static void Main(string[] args)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../XML/Students.xsl");
            xslt.Transform("../../XML/Students.xml", "../../Students.html");
        }
    }
}

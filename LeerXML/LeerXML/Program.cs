using System.Xml;

namespace LeerXML { 
    class Program
    {
        static void Main(string[] args) {
            try { 
            XmlDocument confi = new XmlDocument();
            confi.Load("Configuraciones.xml");

            foreach (XmlNode n1 in confi.DocumentElement.ChildNodes) //Recorrer nodo raiz n1
            {   
                string name = getValorAtributo(n1, "name"); // Función para obtener el valor del atributo deseado
                Console.WriteLine(name);
                    if (n1.HasChildNodes)//Revisamos si el nodo raiz tiene hijos
                    {
                        foreach (XmlNode n2 in n1.ChildNodes)   //Como los hijos del nodo 1 tienen mas hijos tambien los recorremos 
                        {
                            Console.WriteLine($"{n2.Name} {n2.InnerText}"); //Se acceden a los valores de los atributos del nodo2  
                        }
                    }
                    else {
                        Console.WriteLine("No existen más atributos");
                    }
                Console.WriteLine();
            }
            
            }catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);
            }

        }
            
        static string getValorAtributo(XmlNode node, string nombreAtributo)
        {
            XmlAttribute atributo = node.Attributes[nombreAtributo];
            return atributo != null ? atributo.Value : null; //Si el atributo no existe devuelve null

        }
    }
}
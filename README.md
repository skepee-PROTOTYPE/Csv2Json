# Csv2Json
Json generation from csv file. 
The input file must be provided with a header line in order to create the name and associate with the right value.

A particular case is if the the header name starts with "list_". If the corresponding value is a semicolon separated values, it generates the nested object.

```
   string headline = "title,date,description,imagelink,list_tags";
        List<string> news = new List<string>();

        List<dynamic> l = new List<dynamic>();

        var head = headline.Split(',');

        foreach (var elem in news)
        {
            dynamic z = new System.Dynamic.ExpandoObject();
            var dictionary = (IDictionary<string, object>)z;

            var values = elem.Split(',');

            for (int i = 0; i < head.Length; i++)
            {
                var k = head[i].Trim();
                var v = values[i].Trim();

                if (k.StartsWith("list_"))
                {
                    k = k.Replace("list_", "");
                    var lv = v.Split(";");
                    dictionary.Add(k, lv);
                }
                else
                {
                    dictionary.Add(k, v);
                }
            }
            l.Add(dictionary);
        }
```

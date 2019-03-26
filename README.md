# Csv2Json
Json generation from csv file. 
The input file must be provided with a header line in order to create the name and associate with the right value.

A particular case is if the the header name starts with "list_". If the corresponding value is a semicolon separated values, it generates the nested object.

```
string headline; 
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

Examples:


Example 1: Csv simple flat file with header.

| title  | date       | description  | imagelink   | 
|--------|------------|--------------|-------------| 
| title1 | 21/01/2019 | description1 | http://***1 | 
| title2 | 20/01/2019 | description2 | http://***2 | 
| title3 | 19/01/2019 | description3 | http://***3 | 
| title4 | 18/01/2019 | description4 | http://***4 | 
| title5 | 17/01/2019 | description5 | http://***5 | 

json:

```json
[
    {
        "title": "title1",
        "date": "21/01/2019",
        "description": "description1",
        "imagelink": "http://***1"
    },
    {
        "title": "title2",
        "date": "20/01/2019",
        "description": "description2",
        "imagelink": "http://***2"
    },
    {
        "title": "title3",
        "date": "19/01/2019",
        "description": "description3",
        "imagelink": "http://***3"
    },
    {
        "title": "title4",
        "date": "18/01/2019",
        "description": "description4",
        "imagelink": "http://***4"
    },
    {
        "title": "title5",
        "date": "17/01/2019",
        "description": "description5",
        "imagelink": "http://***5"
    }
]
```


Example 2: csv file with header and nested objects

| title  | date       | description  | imagelink   | list_tags      | 
|--------|------------|--------------|-------------|----------------| 
| title1 | 21/01/2019 | description1 | http://***1 | tag1;tag2;tag3 | 
| title2 | 20/01/2019 | description2 | http://***2 | tag2;tag3;tag4 | 
| title3 | 19/01/2019 | description3 | http://***3 | tag4;tag5;tag6 | 
| title4 | 18/01/2019 | description4 | http://***4 | tag6;tag7;tag8 | 
| title5 | 17/01/2019 | description5 | http://***5 | tag7;tag8;tag9 | 


it generates this Json:
```json
[
    {
        "title": "title1",
        "date": "21/01/2019",
        "description": "description1",
        "imagelink": "http://***1",
        "tags": [
            "tag1",
            "tag2",
            "tag3"
        ]
    },
    {
        "title": "title2",
        "date": "20/01/2019",
        "description": "description2",
        "imagelink": "http://***2",
        "tags": [
            "tag2",
            "tag3",
            "tag4"
        ]
    },
    {
        "title": "title3",
        "date": "19/01/2019",
        "description": "description3",
        "imagelink": "http://***3",
        "tags": [
            "tag4",
            "tag5",
            "tag6"
        ]
    },
    {
        "title": "title4",
        "date": "18/01/2019",
        "description": "description4",
        "imagelink": "http://***4",
        "tags": [
            "tag6",
            "tag7",
            "tag8"
        ]
    },
    {
        "title": "title5",
        "date": "17/01/2019",
        "description": "description5",
        "imagelink": "http://***5",
        "tags": [
            "tag7",
            "tag8",
            "tag9"
        ]
    }
]
```


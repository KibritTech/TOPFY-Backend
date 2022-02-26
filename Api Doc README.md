# TOPFY-Backend
TOPFY API
All of the requests are post requests!
1.	The endpoint to get popular tags with the custom count
http://vahiddev-001-site1.htempurl.com/api/Tags?count=2
count is the number of popular tags that you want to get. 
The result of the above request is 
```
{
    "tags": [
        {
            "parentTagId": 1,
            "parentTagName": "Sport",
            "childrenTags": [
                {
                    "id": 5,
                    "name": "Football"
                },
                {
                    "id": 6,
                    "name": "Basketball"
                },
                {
                    "id": 7,
                    "name": "Volleyball"
                },
                {
                    "id": 8,
                    "name": "Swimming"
                }
            ]
        },
        {
            "parentTagId": 2,
            "parentTagName": "Travelling",
            "childrenTags": [
                {
                    "id": 13,
                    "name": "Hiking"
                },
                {
                    "id": 14,
                    "name": "Alpinism"
                },
                {
                    "id": 15,
                    "name": "Fishing"
                },
                {
                    "id": 16,
                    "name": "Photography"
                },
                {
                    "id": 17,
                    "name": "Camping"
                }
            ]
        }
    ]
}
```
By this request, you get the popular tags and all of their child tags.
2.	The endpoint to get posts with the custom count
http://vahiddev-001-site1.htempurl.com/api/Posts?count=2
Note that, you should also send a body with the following props 
```
{
    "currentPage":3,
    "tags":[
        {
        "id": 4,
        "name": "Cooking"
        },
        {
        "id": 1,
        "name": "Sport"
        }
    ]
}
```
currentPage- The current page that the user wants to access.
Tags- all the tags that the user chose to get the corresponding posts
The result of the above request looks like this 
```
{
    "currentPage": 3,
    "hasNext": true,
    "hasPrevious": true,
    "totalCount": 23,
    "posts": [
        {
            "id": 28,
            "mainImage": "cooking5.jpg",
            "description": "Dummy Description",
            "user": {
                "image": "vahidCook.jpg",
                "userName": "vahidCook"
            },
            "mainTagId": 4,
            "specificTags": []
        },
        {
            "id": 29,
            "mainImage": "cooking6.jpg",
            "description": "Dummy Description",
            "user": {
                "image": "vahidCook.jpg",
                "userName": "vahidCook"
            },
            "mainTagId": 4,
            "specificTags": []
        }
    ],
    "tags": [
        {
            "id": 4,
            "name": "Cooking"
        },
        {
            "id": 1,
            "name": "Sport"
        }
    ]
}
```
In the next requests for paginated posts the request should again contain a body with an array of tags and currentPage. And Count should be specified in the query string 
http://vahiddev-001-site1.htempurl.com/api/Posts?count=10
```
{
    "currentPage":1,
    "tags":[
        {
        "id": 4,
        "name": "Cooking"
        },
        {
        "id": 1,
        "name": "Sport"
        }
    ]
}
```

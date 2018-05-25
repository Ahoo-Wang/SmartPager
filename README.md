# SmartPager

## Install(Nuget)

``` csharp
Install-Package SmartPager -Version 1.0.8
```

## Demo

``` csharp
        public IActionResult Index(int p=1)
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            var pagedList = list.ToPagedList(p, 10, 1000);
            return View(pagedList);
        }
```

## Demo (Razor)

``` csharp
@using SmartPager

@model IPagedList<int>


@Html.Pager(pagedList, new PagerOptions
{
    CssClass = "pagination",
    PageIndexParameterKey = "p",
})
```

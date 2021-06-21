<div dir="rtl" align="right" >

<br/>
<br />
<p align="center">
  <a href="#">
	<img src="https://raw.githubusercontent.com/1Riyad/Project04_Auth_CRUD_ASP.NET/main/Keraa/IMGs/logo.PNG" alt="Keraa Logo" width="110"/>
  </a>

  <h3 align="center"> كِراء | Keraa </h3>

  <p align="center">
    وجهتك الفريده لتأجير وإستئجار المستلزمات، والتواصل مع الآخرين بكل امان
    <br />
     <br />
    </p>
</p>


  </p>


### المقدمــة | Introduction
 كراء هو تطبيق لجميع فئات المجتمع. حيث في كراء يوجد جميع المستلزمات الجاهزة للإجار. فبإمكانك استئجار ما يلزمك لفترة محددة دون التورط بشراء منتجد جديد, والذي بدورة قد لا يلزمك إلا لعدة مرات. بالإضافة الي مقدرتك بالتسجيل في الموقع وعرض منتجاتك!
    في كراء: استأجر  وأجّر.. وأيضا تواصل مع الاخرين! يوجد خاصية التواصل مع ممتلكي المنتجات بشكل خاص ودون توقف! 
</div>

### Demo  
![Demo](https://github.com/1Riyad/Project04_Auth_CRUD_ASP.NET/blob/main/Keraa/IMGs/Demo.gif)
### Wireframe 
[Can be found here](https://github.com/1Riyad/Project04_Auth_CRUD_ASP.NET/tree/main/Keraa/IMGs) 

## Developer Setup:
### Prerequisites:
- NET 5 
- ASP.NET MVC
- Microsoft SQL Server 
- Google Map API Key <a href="https://developers.google.com/maps">Google Maps Platform APIs</a>
- An account in <a href="https://cloudinary.com/"> Cloudinary </a>

### Set up:  
From the command line:

##### - Clone the repo
  ```
  git clone https://github.com/1Riyad/Project04_Auth_CRUD_ASP.NET
  ```

##### - Go into the project directory
  ```
  cd Project04_Auth_CRUD_ASP.NET/Keraa
  ```
##### -  Store your Google Map API key in User Secrets storage
  ```
  dotnet user-secrets set "GoogleToken" "<your_key>"
  ```
##### -  Store your Cloudinary API keys in the  *secrets.json* file as following:
  ```json
 ...
 { 
   "AccountSettings": {
          "CloudName": "<your_cloud_name>",
          "ApiKey": "<your_token_key>",
  	"ApiSecret": "<your_secret_key>",
  	"ApiBaseAddress": "<your_Api_base_address>"
	}
}
  ```
> <small style="font-size: 10px;"> Note: the JSON structure would flattened after any modifications via `dotnet dotnet user-secrets set`, so we need to store the keys via *secrets.json* file itself.</small>
> 

##### -  Database: create your database and schema
 ``` 
 dotnet ef database update
 ```
 
##### -  Run the app
  ```
  dotnet run
  ```

## Built With:
#### Front-End  
 - HTML
 - CSS
 - JS
 - JS DOM
 - Bootstrap
 - Materialize.

#### Back-End 
 - ASP.NET MVC
 - MSSQL Server
 - EF Core
 - ASP.Net Core SignalR
 
## Contributing

Pull requests for new features, bug fixes, and suggestions are welcome! Any contributions you make are greatly appreciated.
- Fork the Project
- Create your Feature Branch (git checkout -b AmazingFeature)
- Commit your Changes (git commit -m 'Add some AmazingFeature')
- Push to the Branch (git push origin AmazingFeature)
- Open a Pull Request

 
## Devoloper
> Riyad Alghamdi - رياض الغامدي

> Project Link: [Keraa](https://github.com/1Riyad/Project04_Auth_CRUD_ASP.NET)

## License
Distributed under the MIT License.

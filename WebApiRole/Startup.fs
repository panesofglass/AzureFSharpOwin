namespace WebApiRole

open Owin
open System.Net
open System.Net.Http
open System.Web.Http

type RouteOptions = { id: RouteParameter }

type Startup() =
    member x.Configuration(app: IAppBuilder) =
        let config = new HttpConfiguration()
        config.Routes.MapHttpRoute("Default", "{controller}/{id}", { id = RouteParameter.Optional }) |> ignore
        app.UseWebApi(config) |> ignore

type TestController() =
    inherit ApiController()
    member x.Get() =
        "Hello from OWIN!"
    member x.Get(id) =
        sprintf "Hello from OWIN, id %d" id

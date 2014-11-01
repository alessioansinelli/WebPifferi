<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);
    }

    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.MapPageRoute("newsdetail","news/{slug}","~/dettaglionews.aspx");
        routes.MapPageRoute("news", "news", "~/news.aspx");
        routes.MapPageRoute("storia", "storia", "~/lanostrastoria.aspx");
        routes.MapPageRoute("fotovideo", "fotovideo", "~/fotovideo.aspx");
        routes.MapPageRoute("contatti", "contatti", "~/contatti.aspx");
        routes.MapPageRoute("strumenti", "strumenti", "~/strumenti.aspx");
        routes.MapPageRoute("gallerydetail", "gallery/{slug}", "~/photogallery.aspx");
        routes.MapPageRoute("videodetail", "video/{slug}", "~/video.aspx");
        routes.MapPageRoute("piffero", "strumenti/ilpiffero", "~/ilpiffero.aspx");
        routes.MapPageRoute("tamburo", "strumenti/iltamburo", "~/iltamburo.aspx");  
    }

    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e) 
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>

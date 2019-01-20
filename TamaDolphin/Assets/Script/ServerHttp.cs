using UnityEngine;
using System.Collections.Generic;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

public class ServerHttp : MonoBehaviour
{

    public NetworkEventManager networkEventManager;
    public delegate void RequestHandler(Match match, HttpListenerResponse response, string contRead);

    private Dictionary<Regex, RequestHandler> _requestHandlers = new Dictionary<Regex, RequestHandler>();

    HttpListener _listener;

    private bool isMatching = false;
    private bool isWeb = false;
    private bool isSam = false;
    public bool clickButton = false;
    public string stringaLetta;

    void Update()
    {
        if (isMatching)
        {
            if (isWeb)
            {

                isMatching = false;
                isWeb = false;
                WebButtonFunction(); //test 

            }
            if (isSam)
            {

                isMatching = false;
                isSam = false;
                SamFunction(); //test 

            }
        }
    }

    void Awake()
    {
        // create the dictionnary of Regex and RequestHandler
        _requestHandlers[new Regex(@"^/Sam$")] = HandleSamWebResponse;
        _requestHandlers[new Regex(@"^/Rfid$")] = HandleCardRfidResponse;
        _requestHandlers[new Regex(@"^/Web$")] = HandleWebResponse;
        _requestHandlers[new Regex(@"^.*$")] = HandleSamResponse;
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("ciao");

        _listener = new HttpListener();
        _listener.Prefixes.Add("http://+:8081/");

        _listener.Start();

        _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
    }

    void Destroy()
    {
        if (_listener != null)
        {
            _listener.Close();
        }
    }

    
    private void HandleSamWebResponse(Match match, HttpListenerResponse response, string contRead)
    {

        if (contRead == "1")
        {

            clickButton = true;
            Debug.Log("configurazione avvenuta con successo");
            
        }
       
    }

    private void HandleCardRfidResponse(Match match, HttpListenerResponse response, string contRead)
    {

        Debug.Log("messaggio ricevutoSam");
        Debug.Log(contRead);

        networkEventManager.HandleSamCardRead(contRead);

    }

    private void HandleSamResponse(Match match, HttpListenerResponse response, string contRead)
    {
        stringaLetta = contRead;
        isMatching = true;
        isSam = true; 
    }

    public void SamFunction()
    {
        SamEvents samEvents = new SamEvents();
        samEvents = JsonUtility.FromJson<SamEvents>(stringaLetta);
        if (samEvents.events[0].dur == 0)
        {
            //GameObject questionMark = (GameObject)Instantiate(Resources.Load("QuestionMark"));
            //Vector3 position1 = new Vector3(0, 0, 10);
            //Instantiate(questionMark, position1, questionMark.GetComponent<Transform>().rotation);
            string idLetto = samEvents.events[0].val;
            Debug.Log("messaggio ricevutoSam");
            Debug.Log(stringaLetta);

            networkEventManager.HandleSamCardRead(idLetto);
        }
    }
   
    private void HandleWebResponse(Match match, HttpListenerResponse response,  string contRead)
    {
        stringaLetta = contRead;
        isMatching = true;
        isWeb = true;
      
    }

    private void WebButtonFunction()
    {

        //GameObject questionMark = (GameObject)Instantiate(Resources.Load("QuestionMark"));
        //Vector3 position1 = new Vector3(5, 5, 5);
        //Instantiate(questionMark, position1, questionMark.GetComponent<Transform>().rotation);
        string contRead = stringaLetta;
        Debug.Log("messaggio ricevuto");
        Debug.Log(contRead);

        networkEventManager.HandleWebButtonPressed(contRead);
    }



    public string TherapistButtonValue(string buttonValue)
    {
        
        string val = string.Empty;
        

        for (int i = 0; i < buttonValue.Length; i++)
        {
            if (Char.IsDigit(buttonValue[i]))
                val += buttonValue[i];
        }

        if (val.Length == 1 && (val=="0"|| val == "1" ))
        {
           return val;
        }
        else return "qualcosa è andato storto nella stringa passata dal sito web";
    }

    


    private void ListenerCallback(IAsyncResult result)
    {
        Debug.Log("Messaggio http ricevuto");
        HttpListener listener = (HttpListener)result.AsyncState;
        // Call EndGetContext to complete the asynchronous operation.
        HttpListenerContext context = listener.EndGetContext(result);
        HttpListenerRequest request = context.Request;
        // Obtain a response object.
        HttpListenerResponse response = context.Response;
        string contRead = new StreamReader(request.InputStream).ReadToEnd();
        

        
        foreach (Regex r in _requestHandlers.Keys)
        {
            Match m = r.Match(request.Url.AbsolutePath);
            if (m.Success)
            {
                (_requestHandlers[r])(m, response, contRead);
                // server waits for the next request
                _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
                return;
            }
        }

        response.StatusCode = 404;
        response.Close();
    }


}

[Serializable]
public class SamEvents
{
    public Evt[] events;

}

[Serializable]
public class Evt
{
    public string typ;
    public string val;
    public bool act;
    public int dur;
}

public static class IPManager
{
    public static string GetLocalIPAddress()
    {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
}

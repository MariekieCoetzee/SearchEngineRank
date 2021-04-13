# Search Engine Rank web application

This application returns domain ranking performances, in an online title search.

<img width="675" src="https://github.com/MariekieCoetzee/SearchEngineRank/blob/master/SearchEngineRank/Images/SearchRequest.png" />

The keyword and domain fields are prepopulated with 'online title search' and 'infotrack.com.au' respectfully. 
A selection of search engines are available.  The results will be based on static pages provided by InfoTrack.

Different domains can be searched to view their ranking positions. 

The result will be displayed on a new screen and provides a back navigation button.

<img width="675" src="https://github.com/MariekieCoetzee/SearchEngineRank/blob/master/SearchEngineRank/Images/SearchResult.png" />

## Design Considerations

<img width="675" src="https://github.com/MariekieCoetzee/SearchEngineRank/blob/master/SearchEngineRank/Images/Design.png" />

## Current version

The current version supports static pages provided by InfoTrack. This can be extended with Bing and Google live sites
by adding two new factory implementations.

## Future extensibility

- Adding Google and Bing live sites.
- Inject React

## How to run the application

The application is developed in Visual Studio 2019.

It is an MVC web application, build on .Net Core 3.1 framework. 

It can be run in a compatible IDE.

xUnit & Moq library is installed for testing.

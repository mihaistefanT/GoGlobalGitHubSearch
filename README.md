# GoGlobalGitHubSearch
This will use GitHubs search function and enable a user to bookmark repositories

To run: 
1: clone the repository in Visual Studion 2019
2: Load GoGlobalGitHubSearch.sln
3: run it using ISS or your favorite browser

Work in progress:
Reqirements:
1.Build Login page for the system – all other pages are restricted (Use Session)
 resolution: login page was created, the authentification does not work
 
2.Build Search page for Github Repositories contains search box and button
3.When searching (by pressing a button or using the Enter key) you will perform a request to:
https://api.github.com/search/repositories?q=YOUR_SEARCH_KEYWORD
4.Render the results as gallery items where each item will show to repository name, avatar of the 
owner, repository description, and a bookmark button (please try to style the gallery as pretty as 
you can)
 Resolution: the search page was made and works as expected getting 30 repos at a time
 
 5.When a user bookmarks a repository you will store the entire result to DB
 Resolution: This was not attepted due to me being rusty with migrations 
 
 6. When user click the bookmark button please open popup with textbox - send email message
 with SMTP (create new fake Gmail account only for this task) to the email address that user insert 
 to the popup textbox (use validations).
 Resolution: Code is in place, needs another SMTP provider as the google one does not authentificate.
 
 7. Add a Bookmark Page that will show all the bookmarked repositories with option to unbookmark 
  repository.
  Resolution: the page was created but the functionality is not there due to time constraints
  
 8. Add Export button to export the bookmarked repositories to csv/xls file.
  Resolution: i've left comments on how i would have done it. 

  


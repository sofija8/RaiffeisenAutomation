Feature: Navigating from Bausparen page to other pages
    As a user
    I want to able to move around the other pages of the website


    Scenario #1: Successfully navigate to the Gewinntabellen page
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user clicks on "Produkte vergleichen" button on this page
        Then Gewinntabellen page should open (https://www.bausparen.at/de/bausparen/gewinntabellen.html)

    Scenario #2: Successfully navigate to the Services page
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user clicks on "Services" from the navigation bar
        Then Services page should open (https://www.bausparen.at/de/services.html)

    Scenario #3: Successfully navigate to the Login page
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user hovers over "Bausparen" from the navigation bar
        And A user clicks on "Online Bausparen" (Jetzt bausparen) button 
        Then Login page should open (https://sso.raiffeisen.at/mein-login/identify) in a new tab

    Scenario #4: Successfully navigate to the MixZins Bausparen page 
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user scrolls down to "Unsere Produkte" carousel and clicks on second slide
        And A user clicks on "Zum Produkt" button on MixZins Bausparen carousel item, which now appears on the screen
        Then MixZins Bausparen page should open (https://www.bausparen.at/de/bausparen/mixzins.html)

    Scenario #5: Successfully navigate to the Contact Form on Kontakt page
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user scrolls down to the bottom of the page
        And A user clicks on "Kontaktformular" link
        Then Kontakt page should open (https://www.bausparen.at/de/kontakt.html#kontaktformular)

    Scenario #6: Successfully navigate to the Gesundheit & Pflege page
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user hovers over "Finanzieren" from the navigation bar
        And A user clicks on "Gesundheit & Pflege" link 
        Then Gesundheit & Pflege page should open (https://www.bausparen.at/de/finanzieren/gesundheit.html)



Feature: Embed YouTube video
    As a user
    I want to be able to watch embed YouTube video on the Bausparen Page


    Scenario #1: Successfully play the YouTube video
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user clicks Play on the embed video
        Then The YouTube video should start playing

    Scenario #2: Successfully pause the Youtube video
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user clicks Play on the embed video
        And A user then clicks Pause on the embed video
        Then The YouTube video should pause



Feature: Search for certain text - keyword(s)
    As a user
    I want to be able to perform Search action based on passed text


    Scenario #1: Successfully perform a search action based on the entered keyword(s)
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user enters some text (keywords) in the Search field
        And A user hits Enter button
        Then The corresponding page with search results (that contain the passed text) should open

    Scenario #2: Search the term for which there will not be any results
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user enters some text (keywords) in the Search field (text should be completely different from the subject)
        And A user hits Enter button
        Then The page with 0 search results should open, displaying the corresponding message



Feature: Newsletter Subscription
    As a user
    I want to subscribe to the Newsletter


    Scenario #1: Successfully subscribe to Wohnwelt newsletter
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user enters a valid email into the Newsletter form
        And A user clicks on "Absenden" button
        Then Subscription confirmation should display on the screen, instead of the form

    Scenario #2: Display warning if email address is not in correct format
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user enters an invalid email into the Newsletter form
        And A user clicks on "Absenden" button
        Then Warning message should display



Feature: Search for ATM and bank locations
    As a user
    I want to search for ATM/bank locations based on passed text


    Scenario #1: Succcessfully search for ATM/bank location
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user scrolls down and enters some text into the search field (city or a town name, for example)
        And A user clicks one of the suggestions from search autocomplete which displayed on the screen
        Then A new content box will appear over the screen which contains a map, filters and list of all available ATM/bank locations that match the passed text

    Scenario #2: Succcessfully search for ATM/bank location and then reset search
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        And A user gets the location search results based on the passed text
        When A user clicks "Abbrechen" button
        Then Search field will be cleared from the previously passed text
        And Location search results will disappear from the screen
        And A user will be able to perform new search action

    Scenario #3: Search location for which there will not be any results
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        When A user scrolls down and enters some text (location that is not supported) into the search field
        Then Warning message should display on the screen

    Scenario #4: Successfully open one of the results (locations)
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        And A user gets the location search results based on the passed text
        When A user clicks on one of the results
        And A user clicks on "Detailseite aufrufen" button
        Then The corresponding page with more details related to the chosen bank should open

    Scenario #5: Successfully open one of the results and then go back to the results list
        Given A user opens Bausparen page (https://www.bausparen.at/de/bausparen.html)
        And A user gets the location search results based on the passed text
        When A user clicks on one of the results
        And A user clicks on "Detailseite aufrufen" button in order to see the details about location
        And A user clicks on "Zurück" in the top left corner of the item
        Then A user goes back to the list of all available ATM/bank locations that match the passed text
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



const myfield = document.getElementById('searchField') 
const MyButton = document.getElementById('MyButton')


var allData
MyButton.onclick = (e) => {
    e.preventDefault() // shup no kelmah 
    console.log()


    // get the value of the search field 
    const stringtoBeEncoded = myfield.value 
   
    // encode 
    console.log("https://api-v2.soundcloud.com/search?q=" + encodeURIComponent(stringtoBeEncoded) + '&variant_ids=2312%2C2317&query_urn=soundcloud%3Asearch-autocomplete%3A6eba7ba617f646a1af8a2e300c18ce19&facet=model&user_id=46726-222037-615806-192133&client_id=T8UEvzokCfP8THzGpUYqjgLkuWITxLPG&limit=20&offset=0&linked_partitioning=1&app_version=1623915700&app_locale=en');
    // append to the url 
    const getHussain = () => {
        fetch('https://api-v2.soundcloud.com/search?q=' + encodeURIComponent(stringtoBeEncoded) + '&variant_ids=2312%2C2317&query_urn=soundcloud%3Asearch-autocomplete%3A6eba7ba617f646a1af8a2e300c18ce19&facet=model&user_id=46726-222037-615806-192133&client_id=T8UEvzokCfP8THzGpUYqjgLkuWITxLPG&limit=20&offset=0&linked_partitioning=1&app_version=1623915700&app_locale=en')
            .then(response => response.json())
            .then(data => document.getElementById("URL").value = data.collection[0].permalink_url);
    }
    getHussain();
    // get request 

    // get the first url in the collection with field name == permalink_url 


    // set value of the url field 

}

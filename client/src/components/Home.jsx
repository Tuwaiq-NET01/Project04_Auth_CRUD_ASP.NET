import React, { useState,useEffect } from 'react';
import { Router, Link, navigate } from '@reach/router';
import axios from 'axios';
import Fade from 'react-reveal/Fade'; 
import Footer from './Footer';
function Home(props) {

const [allTours, setAllTours] = useState([]);

  useEffect(() => {
   // setjwtStr(Storage.get("token"))
   // console.log(Storage.get("token"))
    getAll();
},[ ]);


const getAll = () => {
     
  console.log("handle submit")

  axios.get('https://localhost:44364/api/AllTours')
    .then((res) => {
      console.log(res.data)
      setAllTours(res.data)
    })
    .catch((error) => {
      console.error(error)
    })
   
}





    return (
        <>



  <nav class="navbar yellow navbar-expand-md navbar-dark ">
  
    <div class="navbar-collapse collapse" id="navbar4">
        <ul class="navbar-nav">
         
            <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/">Home </Link></li> 
     
            <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/login">Login </Link></li>
            {/* <li className="nav-item"><Link className ="nav-link pr-3 nav-item-home" to="/test">test </Link></li> */}

        </ul>
    </div>
</nav>



    {/* <div class="header-img"></div> */}

    <section className="img-banner d-flex align-items-center justify-content-center">
            {/* <h1>hi</h1>  */}
</section>
<img   className = "img02" src= '/Daco_5899873.png' alt="logo">

</img>
<p className = "p01">Welcome to KSA’s Best Tours: <br/><a className = "a01" href="/">https:// KSABest.com</a></p>


<div>

<h2 className="text-center">Tourism in Saudi Arabia</h2>

<p className="text-left  intro">

Saudi Arabia is the second biggest tourist
 destination in the Middle East with over 16 million visiting in 2017.
  Although most tourism in Saudi Arabia still largely involves religious pilgrimages,
   there is growth in the leisure tourism sector. As the tourism sector has been largely boosted lately, the sector is expected to be the white oil for Saudi Arabia.Potential tourist areas include the Hijaz and Sarawat Mountains, 
Red Sea diving and a number of ancient ruins.
</p>

</div>
    <div class="container">
    {allTours.map((m,i)=>{
    return(
<div className="card cardOne" style={{textAlign:"center"}}>
 <div className="card-header" style={{fontSize:20, textAlign:"center"}}> <b>{m.place}</b> </div>
  <img src= {m.imageSrc}  alt="capture" style={{width: "370px", height:"300px" }} /> 
  <div class="card-body">
    <p>   {m.description}</p>
  </div>

  <div class="text-center mb-3">
  <Link to={`/book/${m.tourId}`}      className="btn btn-info pl-4"   >Book   </Link> 

  </div>
</div> 
    )
})
}
     </div>

<div className = "bottom">
     <section className="text-center mb-5  sec1">
              <div className="col-lg-10 mx-auto  py-5">
                  <h2 className="title-h2">About us</h2>
                  <p className="  intro"> 
                  Discover all that our region has to offer.
                   KSA’s Best Tours offers our country to you, bringing visitors to the most beautiful, moving, exciting and exhilarating destinations around the region. Whatever you’re looking to experience in your time here, do it with us.
                   KSA’s Best Tours Tours offers a huge range of one day trips to some of the most beautiful destinations around the city. 
                   From soaring cliffs to lush rainforests, beaches to historic places, our tours take you to the most iconic parts of our country. With a full selection of one day or more tours and sightseeing trips leaving daily from some specific cities city, there’s something for everyone in our range. For those who want a one-of-a-kind trip, we also offer private charter to some of the most beautiful destinations around the city.
                  
                  </p>
               </div>
          </section>
           

          <section className="mb-0">
          <Fade right duration={2600} delay={100}>
            <div className="row no-gutters">
              <div className="col-lg-6 order-lg-2 "><img src="https://www.abouther.com/sites/default/files/2018/11/06/main_-_janadriyah_festival.jpg" alt="paint" className="imgg"/></div>
              <div className="col-lg-6 order-lg-1 my-auto px-5">
                <h2 className="title-h2">Events</h2>
                <p className="lead mb-0 intro">In the years since its inception, Saudi Entertainment and Amusement (SEA) expo has established itself as the largest platform for international and local suppliers of entertainment & leisure products and services to interact face-to-face and do business with 5000+ key buyers who play an integral role in Saudi Arabia’s USD 64 billion emerging leisure market.
According to a new industry report, the Saudi entertainment and amusement sector is forecast to be worth $1.17 billion by 2030 and grow by a massive 47.65% per year. </p>
              </div>
            </div>
          </Fade>
          <Fade left duration={2600} delay={200}>
            <div className="row  no-gutters">
              <div className="col-lg-6 order-lg-1 " ><img src="https://en.vogue.me/image_provider/?w=750&h=&zc=1&q=90&cc=ffffff&src=https://ar.vogue.me/wp-content/uploads/2018/03/Diriyahpic.jpg"alt="paint" className="imgg"/></div>
              <div className="col-lg-6 order-lg-2 my-auto px-5  ">
                <h2 className="title-h2">Explore Heritage sites</h2>
                <p className="lead mb-0 ">Saudi Arabia currently has five World Heritage sites inscribed in the list, namely Al-Ahsa Oasis, Al-Hijr Archaeological Site, At-Turaif District of ad-Dir'iyah, historic Jeddah, and the rock art of the Hail Region..</p>
              </div>
            </div>
          </Fade>
          <Fade right duration={2600} delay={300}>
            <div className="row no-gutters ">
              <div className="col-lg-6 order-lg-2 "><img src= "https://i0.wp.com/alhtoon.com/wp-content/uploads/2018/07/FE1FE1DF-6B9A-4DCA-9066-7FAD12D36C3D.jpeg?w=999&ssl=1" alt="paint" className="imgg"/></div>
              <div className="col-lg-6 order-lg-1 my-auto px-5">
                <h2 className="title-h2"> Nature </h2>
                <p className="lead mb-0"> There are many nature places  in KSA, that could attrack the visitor from overseas .</p>
              </div>
            </div>
            </Fade>
          </section>

          {/* <section id="quotes-section" className="text-center mb-3 py-5">
            <div className="container">
              <div className="row">
              <div className="col-lg-6 mx-auto my-5">
                  <p className="lead mb-0"><q>.</q><span className="quote-by"></span></p>
                </div>
                <div className="col-lg-6 mx-auto my-5">
                <p className="lead mb-0"><q>.</q><span className="quote-by"></span></p>
                </div>
              </div>
            </div>
          </section> */}

           <Footer />
       
          </div>

        </>



    );
}

export default Home;
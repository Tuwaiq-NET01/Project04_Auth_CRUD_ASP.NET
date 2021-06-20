import React, {useState, useEffect} from 'react'

export default function Course(props) {
    return (
        <div>
            <div className="card m-3 d-flex justify-content-between" style={{width:"20rem", height:"31rem"}}>
                <div className="text-center">
                    <img className="card-img-top" style={{height:300}} alt="" src='https://img-c.udemycdn.com/course/240x135/543600_64d1_4.jpg?Expires=1624172719&Signature=RzLAi-r4Q2v0erzz9nEiixgMLfq7zviCeF4Y361XSvY1Ucd1yub0uwypvVryspgC6ju6JG33Up2Zct2I0EDDvENFir2FutoT2ifvfyykjsPfgSDCMOSXuzhzKBF60mr-EVplKn-8xGYBtVq9ZzicKIv~fM422bqd5JwZKw5ok4RoVkzXcgFTM9noo~lAjQxFo7sj8vJUg5MD1q8HfUxEmS0QwQkEvuAMT9vz7QoQfVu~6Ts5o4d3Nvx7jJAJpadRtTkSN8UaTBwmho68vCwy1PYE4~cItITVbeCqBn4Wa0lbOeEtsYxjlSHlSat8W-Ui44ExDRV7IuhkTuBw-QmbKA__&Key-Pair-Id=APKAITJV77WS5ZT7262A'/>
                    <h5 className="card-title mt-2">{props.course.details}</h5>
                    <h4 className="card-text">Instructor : {props.course.instructor.name}</h4>
                </div>

                <div className="text-center mt-2">
                        <p className="card-text"><strong >Level of Dificulty : {props.course.levelOfDifficulty}</strong></p>
                        <div className="d-flex justify-content-center">
                            <button className="btn btn-primary mb-2 text-light">Enroll</button>
                            <p className="mt-1 ml-2">Rating : {props.course.rating}/5</p>
                        </div>
                        
                </div>
            </div>
        </div>
    )
}

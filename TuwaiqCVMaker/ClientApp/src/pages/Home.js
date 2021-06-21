import React, { useState } from 'react';
import { Redirect } from 'react-router-dom';
import { Row, Col, Button, Card, CardImg } from 'reactstrap';

function Home() {
    const [redirect, setRedirect] = useState(false);

    if(redirect) {
        return <Redirect to="/editor"/>;
    }

    return (
        <div>
            <div className="home-header pb-5">
                <h1>Tuwaiq CV Maker</h1>
                <Row>
                    <Col xs="4">
                        <Card>
                            <CardImg top width="100%" src="https://i.pinimg.com/originals/88/6b/15/886b1598b09c5c588004570c4fd1e28c.gif" alt="Card image cap" />
                        </Card>
                        <div className="mx-auto text-center mt-3">
                            <Button color="primary" onClick={() => setRedirect(true)}><h3>Get Started</h3></Button>
                        </div>
                    </Col>
                    <Col>
                        <h3>Make an eye catching resume</h3>
                        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                    </Col>
                </Row>
            </div>
            <div className="home-body">
            </div>
        </div>
    );
}

export default Home;

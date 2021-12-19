import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';

import { useState } from "react";
import Modal from "./Modal";


export default (props) => {
    const [isModalOpen, setisModalOpen] = useState(false);

    const deleteHandler = () => setisModalOpen(true);

    return (
        <div>
            <Card style={{ width: '18rem' }}>
                <Card.Body>
                    <Card.Title>{props.header}</Card.Title>
                    <Card.Text>
                        {props.header} Description
                    </Card.Text>
                    <Button variant="primary" onClick={deleteHandler}>Delete</Button>
                </Card.Body>
            </Card>
            {isModalOpen ? <Modal isModalOpen={isModalOpen} setisModalOpen={setisModalOpen} /> : null}
        </div>
    )
}
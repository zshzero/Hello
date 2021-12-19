import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

export default (props) => {
    const handleClose = () => props.setisModalOpen(false);

    return (
        <Modal
            show={props.isModalOpen}
            onHide={handleClose}
            backdrop="static"
            keyboard={false}
        >
            <Modal.Header closeButton>
                <Modal.Title>Delete</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                Do You want to Delete the Task ?
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Cancel
                </Button>
                <Button variant="primary">Delete</Button>
            </Modal.Footer>
        </Modal>
    );
}

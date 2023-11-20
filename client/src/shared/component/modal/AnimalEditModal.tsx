import { Modal, ModalBody, ModalHeader } from "react-bootstrap"
import { Animal } from "../../lib/types"

type AnimalEditModalType = {
    toggleEditModal : boolean,
    handleModalHide : () => void,
    animal : Animal
}

const AnimalEditModal = ({ toggleEditModal, handleModalHide, animal } : AnimalEditModalType) => {
    return (
        <Modal show={toggleEditModal} onHide={handleModalHide}>
            <ModalHeader>
                saiaSmdkakmsdmkaskmd
            </ModalHeader>
            <ModalBody>
asknodoanosdnioasdoinasinho
            </ModalBody>
        </Modal>
    )
}

export default AnimalEditModal
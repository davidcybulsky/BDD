import React, { useState } from 'react'
import { Container,Modal, Form, Button, Col, Row, Stack} from 'react-bootstrap'
import DateGroup from '../formcomponent/DateGroup';
import EncloserGroup from '../formcomponent/EncloserGroup';
import { TicketDataType } from '../../lib/types';
import { initTicketData } from '../../../util/util';

type TicketModalType = {
    toggleModal : boolean,
    handleModalHide : () => void
}

const TicketModal = ({ toggleModal, handleModalHide } : TicketModalType ) => {
    const [ticketData, setTicketData] = useState<TicketDataType>(initTicketData);

    const handleDateOnChange = (event : React.ChangeEvent<HTMLInputElement>) => {
        // setDte(event.target.value) //rok miesiac dzien
        const date = event.target.value 
        if(date) {
            setTicketData({ ...ticketData, date : event.target.value})
        } else {
            //alert zwiazany ze zla data
        } 
    }
    const handleModalHideAndCache = () => {
        setTicketData({
            date : "",
            safari : ''
        })
        handleModalHide();
    }
    const handlePickSafari = (value : string) => {
        if(value) {
            setTicketData({ ...ticketData, safari : value})
        } else {
            //alert zwiazany ze zla data
        } 
    }
    const handleBuyTicket = () => {
        if(ticketData.date !== "" && ticketData.safari !== "") {
            //post do bazy danych
        }
        else {
            //alert 
        }
    }
    return (
        <Modal show={toggleModal} onHide={handleModalHideAndCache} className='p-3'>
            <Modal.Header closeButton>
                <h4>
                    Buy ticket
                </h4>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <DateGroup handleDateOnChange={handleDateOnChange}/>
                    <EncloserGroup handlePickSafari={handlePickSafari}/>
                    <p>Cena</p>
                    
                    <Stack direction='horizontal' gap={2} className='justify-content-center'>
                        <Button type="submit" onClick={handleBuyTicket}>
                            Submit
                        </Button>
                        <Button type="submit" onClick={handleModalHideAndCache} variant='outline-primary'>
                            Cancel
                        </Button>
                    </Stack>
                </Form>
            </Modal.Body>
        </Modal>
    )
}

export default TicketModal
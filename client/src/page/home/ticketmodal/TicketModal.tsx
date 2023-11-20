import React, { useState } from 'react'
import { Container, Form } from 'react-bootstrap'
import DateGroup from '../../../shared/component/formcomponent/DateGroup';
import EncloserGroup from '../../../shared/component/formcomponent/EncloserGroup';
import { TicketDataType } from '../../../shared/lib/types';


const TicketModal = () => {
    const [date, setDate ] = useState<string>('');
    const [ticketData, setTicketData] = useState<TicketDataType>();
    const handleDateOnChange = (event : React.ChangeEvent<HTMLInputElement>) => {
        setDate(event.target.value) //rok miesiac dzien 
    }
    const handlePickSafari = (value : string) => {

    }
    return (
        <Container>
            <Form>
                <DateGroup handleDateOnChange={handleDateOnChange}/>
                <EncloserGroup handlePickSafari={handlePickSafari}/>
            </Form>
        </Container>
    )
}

export default TicketModal
import React from 'react'
import { Form} from "react-bootstrap"

type DateGroupType = {
    handleDateOnChange : (event : React.ChangeEvent<HTMLInputElement>) => void 
}

const DateGroup = ( { handleDateOnChange } : DateGroupType) => {
  return (
    <Form.Group>
        <Form.Label htmlFor='date'>Date:</Form.Label>
        <Form.Control
            id='date'
            type='date'
            onChange={handleDateOnChange}
        />
    </Form.Group>
    )
}

export default DateGroup
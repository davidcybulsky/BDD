import React, { useState } from 'react'
import { Form } from "react-bootstrap"

type EncloserGroupType = {
    handlePickSafari : (value : string) => void
}

const EncloserGroup = ( { handlePickSafari } : EncloserGroupType ) => {
    const [pickedSafari, setPickedSafari] = useState<string>('');
    const safari = ["NORTHERN", "SOUTHERN", "EASTERN", "WESTERN"]
    const handleOnChangeSafari = (e : React.ChangeEvent<HTMLSelectElement>) => {
        setPickedSafari(e.target.value)
        handlePickSafari(e.target.value)
    }   
    return (
        <Form.Group>
            <Form.Label htmlFor='safariPicker'>Pick Safari</Form.Label>
            <Form.Select 
                id='safariPicker' 
                value={pickedSafari} 
                onChange={(event) => handleOnChangeSafari(event)}
            >
                <option>Choose your safari</option>
                {
                    safari.map(s => (
                        <option key={s} value={s}>{s}</option>
                    ))
                }
            </Form.Select>
            <p>Cena:</p>
            {/* w zaleznosci od safari taka będzie cena */}
        </Form.Group>
    )
}

export default EncloserGroup
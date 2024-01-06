import http from 'k6/http';
import { sleep } from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '1m', target: 100 },
        { duration: '2m', target: 100 },
        { duration: '1m', target: 200 },
        { duration: '2m', target: 200 },
        { duration: '1m', target: 300 },
        { duration: '2m', target: 300 },
        { duration: '1m', target: 400 },
        { duration: '2m', target: 400 },
        { duration: '4m', target: 0 },
    ]
};

const API_BASE_URL = 'https://localhost:7201';

const caretakerPayload = JSON.stringify({
    firstName: 'Jason',
    lastName: 'Statham',
});


export default () => {

    

    http.batch([
        ['GET', `${API_BASE_URL}/animal`],
        ['GET', `${API_BASE_URL}/caretaker`],
        ['GET', `${API_BASE_URL}/User`],
        ['GET', `${API_BASE_URL}/Ticket`],
    ])

    const reqPost = {
        method: 'POST',
        url: `${API_BASE_URL}/caretaker`,
        body: caretakerPayload,
        params: {
            headers: { 'Content-Type': 'application/json' },
        },
    };

    const resPost = http.batch([reqPost]);
    const caretakerGuid = resPost[0].json().id;

    const reqPut = {
        method: 'PUT',
        url: `${API_BASE_URL}/caretaker/${caretakerGuid}`,
        body: caretakerPayload,
        params: {
            headers: { 'Content-Type': 'application/json' },
        },
    };

    const resPut = http.batch([reqPut]);

    const reqDelete = {
        method: 'DELETE',
        url: `${API_BASE_URL}/caretaker/${caretakerGuid}`,
        body: null,
        params: null
    };

    const resDelete = http.batch([reqDelete]);

    sleep(1);
};
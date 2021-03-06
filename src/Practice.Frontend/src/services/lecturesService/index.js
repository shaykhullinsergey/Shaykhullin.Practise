import axios from 'axios';

class LecturesService {
    static getLecture = (lectureId) =>
        axios.get(`/lectures/${lectureId}`)
            .then(({data}) => {
                console.log(data);
                return data;
            });

    static sendAnswer = (session, data) => axios.post('/quizzes', {
            ...data
        },
        {
            params: {session}
        })
        .then(({data}) => {
            console.log(data);
            return data;
        });
    
    static explicitlyCompletePractice = (session, lectureId) => axios.post(
        '/tasks/complete',
        {lectureId},
        {
            params: {session}
        })
}

export default LecturesService;
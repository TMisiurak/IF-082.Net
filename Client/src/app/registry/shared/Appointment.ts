export class Appointment {
    constructor(
    public id?: number,
    public patientId?: number,
    public doctorId?: number,
    public description?: string,
    public date?: Date,
    public status?: number) {}
}

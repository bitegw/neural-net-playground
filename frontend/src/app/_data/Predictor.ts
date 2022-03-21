export default class Predictor {
    _id: string = '';
    constructor(
        public name: string = 'Novi prediktor',
        public description: string = '',
        public inputs: string[] = [],
        public output: string = '',
        public isPublic: boolean = false,
        public accessibleByLink: boolean = false,
        public dateCreated: Date = new Date()
    ) { }
}
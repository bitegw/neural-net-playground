export default class Dataset {
    _id: string = '';
    constructor(
        public name: string = 'Novi izvor podataka',
        public description: string = '',
        public header: string[] = [],
        public fileId?: number,
        public extension: string = '.csv',
        public isPublic: boolean = false,
        public accessibleByLink: boolean = false,
        public dateCreated: Date = new Date(),
        public lastUpdated: Date = new Date(),
        public username: string = 'tester1'
    ) { }
}
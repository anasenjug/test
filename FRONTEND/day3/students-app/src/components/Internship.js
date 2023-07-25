class Internship {
  constructor(
    studyAreaId,
    studyAreaName,
    companyId,
    companyName,
    companyWebsite,
    companyAddress,
    name,
    description,
    address,
    startDate,
    endDate
  ) {
    this.studyAreaId = studyAreaId;
    this.studyAreaName = studyAreaName;
    this.companyId = companyId;
    this.companyName = companyName;
    this.companyWebsite = companyWebsite;
    this.companyAddress = companyAddress;
    this.name = name;
    this.description = description;
    this.address = address;
    this.startDate = new Date(startDate);
    this.endDate = new Date(endDate);
  }
}

export default Internship;

import type { AuditedEntityDto } from '@abp/ng.core';

export interface AuthorDto extends AuditedEntityDto<string> {
  name?: string;
  email?: string;
  bio?: string;
  dateOfBirth?: string;
}

export interface CreateUpdateAuthorDto {
  name: string;
  email: string;
  bio: string;
  dateOfBirth: string;
}

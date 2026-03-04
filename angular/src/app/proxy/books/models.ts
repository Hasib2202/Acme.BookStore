import type { AuditedEntityDto } from '@abp/ng.core';

export interface BookDto extends AuditedEntityDto<string> {
  name?: string;
  publishDate?: string;
  price?: number;
  authorId?: string;
  authorName?: string;
  categoryId?: string;
  categoryName?: string;
}

export interface CreateUpdateBookDto {
  name: string;
  publishDate: string;
  price: number;
  authorId: string;
  categoryId: string;
}

using AutoMapper;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Categories.CreateCategory
{
    internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isCategoryNameExists = await _categoryRepository.AnyAsync(p=>p.Name == request.Name, cancellationToken);

            if (isCategoryNameExists) 
            {
                throw new ArgumentException("Bu kategori adı daha önce oluşturulmuş!");
            }

            //Category category = new()
            //{
            //    Name = request.Name,
            //};

            //yukarıdaki yerine mapper kullanıldı.

            //request i alıp category e çevirip geri verir. Category i class ında id guid ise doldurmamız gerekir.

            Category category = _mapper.Map<Category>(request); //yenisi oluşur.

            await _categoryRepository.AddAsync(category, cancellationToken); //memory alır
            await _unitOfWork.SaveChangesAsync(cancellationToken); //database kaydeder
        }
    }
}

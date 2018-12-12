using System.Collections.Generic;

namespace Practice
{
	public static class DatabaseConfiguration
	{
		public static bool ShouldUpdateDatabase => false;
		
		public static void Configure(PracticeDatabaseContext context)
		{
			Truncate(context);

			var lectures = CreateLectures();
			
			context.Lectures.AddRange(lectures);

			context.SaveChanges();
		}

		private static void Truncate(PracticeDatabaseContext context)
		{
			context.Answers.RemoveRange(context.Answers);
			context.Chapters.RemoveRange(context.Chapters);
			context.Lectures.RemoveRange(context.Lectures);
			context.Questions.RemoveRange(context.Questions);
			context.Quizzes.RemoveRange(context.Quizzes);
			context.Profiles.RemoveRange(context.Profiles);
			
			context.SaveChanges();
		}

		private static IEnumerable<Lecture> CreateLectures()
		{
			yield return Lecture1();
			yield return Lecture2();
		}

		private static Lecture Lecture1()
		{
			#region Вопросы
			var questions = new List<Question>
			{
				new Question
				{
					Text = "Вопрос 1",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				new Question
				{
					Text = "Вопрос 2",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				new Question
				{
					Text = "Вопрос 3",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				new Question
				{
					Text = "Вопрос 4",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = true },
					}
				},
				new Question
				{
					Text = "Вопрос 5",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				}
			};
			#endregion

			#region Главы
			
			var chapters = new List<Chapter>
			{
				new Chapter
				{
					Title = "Глава 1", Text = @"orem ipsum dolor sit amet, consectetur adipiscing elit. Sed feugiat sapien at velit fermentum, eu malesuada nibh condimentum. Etiam maximus a dolor eu pharetra. Aenean mollis nisl nec massa dictum volutpat. Sed mollis sollicitudin mi ac finibus. Sed pulvinar ligula sed finibus aliquet. Maecenas vestibulum libero nisi, sit amet tincidunt nisl scelerisque ut. Nulla vulputate sapien urna. Cras vulputate eros ullamcorper ipsum lacinia hendrerit. Mauris suscipit porta dui vitae semper.

Suspendisse eu molestie libero, sit amet faucibus purus. In tincidunt, ex quis dictum elementum, ligula sem ornare elit, ut vulputate velit mi vel nulla. Mauris volutpat, erat id rhoncus sagittis, odio nisl iaculis nisi, nec elementum nisl felis sed mauris. Praesent a purus ut felis pulvinar congue ut sed lectus. Integer tincidunt volutpat velit at bibendum. Ut a velit malesuada, viverra augue vel, volutpat diam. In dignissim non dui ut egestas. Integer eleifend hendrerit neque ac ultrices. Quisque vestibulum sem eget condimentum volutpat. Nulla suscipit sapien iaculis mollis dictum. Sed sodales nisi sed justo volutpat posuere. Duis porttitor, tortor sit amet dignissim consequat, felis metus rutrum nulla, ultrices ultricies felis metus et nulla. Suspendisse non efficitur nibh, ut consequat lacus. Duis eget pretium lectus. Aliquam erat volutpat. Integer placerat lectus vel justo mattis, in dignissim nunc tincidunt.

Sed vel odio cursus, ullamcorper arcu eu, vestibulum velit. Duis laoreet congue venenatis. Nunc non sem vel urna fermentum vehicula. Mauris commodo quam vel magna vulputate lacinia. Etiam sed luctus tellus. Pellentesque lobortis aliquet tortor sit amet dignissim. Nam elementum mauris ut scelerisque tincidunt. Vivamus lobortis dolor non odio volutpat, eget gravida felis dignissim. Phasellus congue massa sem, non feugiat nibh congue in. In tincidunt eros sed mauris facilisis dapibus. Mauris scelerisque ultrices magna, a vulputate leo tempus vel. Suspendisse pharetra arcu non velit hendrerit tempor. Mauris id leo mauris. Cras laoreet nulla massa, porttitor ornare lectus fermentum eget. Aenean sodales metus sem, vel imperdiet urna vulputate vel. Donec volutpat urna non mauris placerat, molestie efficitur libero fermentum.

Nulla lacinia finibus mattis. Pellentesque ullamcorper non ipsum nec imperdiet. Suspendisse lacinia magna in ornare dapibus. Mauris non congue lectus. Cras commodo id neque sed volutpat. Pellentesque faucibus in tellus a luctus. Maecenas porta hendrerit euismod. Aliquam tincidunt egestas consectetur.

Nunc bibendum viverra lorem, sit amet blandit enim finibus sit amet. Aenean semper ante hendrerit velit elementum facilisis. Mauris semper turpis ac condimentum consequat. Nullam id euismod lorem. Vivamus aliquet massa in mi aliquam elementum. Fusce luctus non odio et aliquam. Pellentesque erat ligula, aliquam id suscipit ut, vestibulum a erat. Nulla dignissim sapien eu nibh egestas ornare sed vel purus.

Nunc feugiat eget felis in faucibus. Morbi ullamcorper magna enim, at tempor nulla ornare id. Phasellus congue nec mauris tincidunt tincidunt. Quisque cursus aliquam ipsum, at ornare ante sollicitudin id. Nulla porta consectetur mattis. Nam laoreet, risus id pulvinar sagittis, ligula nisl posuere purus, vitae molestie dolor libero ut nunc. Etiam vulputate nibh a nisl vestibulum scelerisque. Sed in rutrum mauris, a malesuada lectus. Aliquam aliquam nisi ante, et fringilla mi vestibulum luctus. Nullam vitae turpis eget nulla pellentesque vehicula. Phasellus venenatis eros sed erat eleifend, id fringilla lectus pharetra. Vestibulum at lorem diam. Aenean ullamcorper non massa sollicitudin facilisis.

Ut non augue nisl. Cras blandit vel justo in condimentum. Proin ac malesuada velit, vel pharetra eros. Duis congue massa at gravida volutpat. Vestibulum leo tortor, fermentum non tempor placerat, eleifend at nisl. Vivamus in sem ac ipsum cursus malesuada. Aenean lobortis elementum sem eget posuere. Proin sit amet lectus placerat elit fermentum viverra. Cras malesuada dictum justo quis suscipit. Vestibulum vel consequat erat. Morbi quis nunc et erat lobortis sagittis. Phasellus efficitur metus eget velit dapibus malesuada nec at ipsum. Donec eu accumsan sem. Phasellus nec mi eget lacus lacinia commodo in eget ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus.

Duis quis ultrices ligula, at vestibulum libero. Suspendisse sollicitudin scelerisque nibh id gravida. Phasellus a vehicula justo, eget vestibulum eros. Nulla gravida aliquam eros ut aliquam. Nam tincidunt quam sed diam feugiat consequat. Duis vitae sem feugiat, interdum libero ut, tincidunt libero. Proin eu purus tempor, tempor nunc nec, fermentum ligula. Donec interdum lorem vitae nibh rhoncus, sit amet suscipit turpis facilisis. Praesent placerat orci nec est ultricies ultricies.

Phasellus a tincidunt justo. Praesent condimentum eleifend risus, quis tincidunt ex consequat vel. Aenean a est rutrum, semper orci quis, semper velit. Sed nec arcu massa. Aenean libero urna, cursus sed massa et, congue ornare dui. Nullam molestie metus tortor, vel lacinia massa tristique id. Nulla at quam lobortis sapien interdum vulputate. Suspendisse nec mattis erat. Aenean ipsum dui, faucibus vel iaculis ut, convallis sit amet erat. Ut lacinia mi nec convallis accumsan. Vivamus iaculis sapien eu neque ullamcorper pulvinar. Suspendisse et semper tortor. In tellus ligula, varius at viverra in, mollis sit amet odio. Vestibulum ut placerat risus, ut varius nisl. Sed et vehicula eros. Nullam tempor id ante ac condimentum.

Suspendisse sed magna neque. Nulla vel turpis massa. Curabitur rutrum rhoncus mi, eu eleifend turpis sollicitudin id. Sed non lacus quis erat consectetur scelerisque vitae eget lectus. Morbi quis mollis ligula, id porttitor quam. Nulla a varius diam. Interdum et malesuada fames ac ante ipsum primis in faucibus. Proin sit amet dui vel quam varius eleifend. Ut iaculis volutpat velit at blandit. Mauris pretium varius iaculis. Ut maximus ultrices libero. Sed nec orci eget felis fringilla ultricies sit amet a ipsum. Mauris id dui a est faucibus pharetra sit amet ut justo. Phasellus volutpat et nibh a fringilla. Duis diam dolor, posuere sit amet libero nec, lobortis porta magna.

Aenean mi nibh, posuere ut cursus dapibus, pulvinar gravida tellus. Praesent id vulputate lorem, ut sagittis augue. Vestibulum at malesuada nisi. Integer pulvinar aliquam tristique. Nam efficitur eleifend accumsan. Etiam et egestas tellus. Quisque nec velit eu ipsum viverra sodales feugiat nec lacus. Aliquam erat volutpat.

Nullam porta, turpis sit amet aliquam consectetur, felis velit rhoncus ligula, quis viverra tortor sapien eget ante. Donec commodo felis eget sem fringilla, sed posuere urna aliquet. Nulla pharetra placerat rhoncus. Maecenas non mi id sapien suscipit ornare at in augue. Donec ac magna tincidunt, tincidunt urna eget, mattis risus. Donec blandit quam id ante tincidunt, sed bibendum tortor lacinia. Aenean consectetur diam accumsan, auctor sapien sed, accumsan ipsum. Nullam vitae ligula non mi facilisis gravida eget a est. Nullam quis ligula id odio pellentesque congue sed porttitor purus. Maecenas fermentum eros in mauris varius varius. Donec viverra ultrices nisi, nec vulputate purus convallis id.

Maecenas eget libero hendrerit, fringilla massa vitae, fermentum neque. Praesent sed scelerisque nibh, eget condimentum nulla. Vivamus nec dui pharetra, congue enim et, ullamcorper metus. Phasellus egestas ultricies commodo. Aliquam lectus urna, dapibus non rhoncus non, iaculis vel turpis. Nulla vel tortor ex. Integer sed pellentesque dui, ac vulputate magna. Sed ac eleifend ligula. Donec iaculis, turpis feugiat imperdiet tincidunt, ex felis porttitor nulla, quis volutpat lorem purus sed nulla. Phasellus elit libero, aliquam vel risus non, faucibus mollis libero. Morbi tristique porttitor erat at sagittis. Cras commodo elementum lacinia.

Nam in efficitur dui, nec sollicitudin sem. Aliquam placerat odio vitae porta luctus. Quisque dapibus semper ante, sed accumsan nulla dignissim vel. Phasellus varius metus sed purus varius tincidunt. Vestibulum blandit ut lorem id viverra. Vivamus tristique neque sed leo dictum, ut gravida nisl semper. Vestibulum rutrum ultricies libero nec viverra. Aliquam ac ex gravida, eleifend metus id, lobortis purus.

Vestibulum nec vestibulum ex. Vestibulum vehicula magna porta sapien aliquam pretium. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Morbi suscipit ligula ex, eget tincidunt elit scelerisque fringilla. Praesent vel volutpat ante, in ornare odio. Duis vel felis commodo enim placerat gravida. Sed et scelerisque nulla. Quisque sit amet orci neque. Curabitur varius ex quis urna ullamcorper pretium vel eget urna. Praesent sodales metus nunc, varius semper augue molestie ac.

Nam pharetra neque leo, ut iaculis turpis cursus quis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Cras faucibus et turpis sit amet lobortis. Donec ut efficitur magna. Pellentesque eu orci a tellus efficitur vestibulum vel vel erat. Nunc ullamcorper pellentesque efficitur. Vestibulum augue sem, dictum a convallis nec, eleifend vitae massa.

Pellentesque vehicula felis nec ex malesuada efficitur. Quisque sapien nibh, mattis et tincidunt ut, pellentesque vel libero. Etiam dui justo, bibendum ut tortor vitae, finibus rutrum libero. Integer eleifend sollicitudin quam, quis suscipit ipsum posuere eu. Suspendisse nec dui quis nisl gravida hendrerit at ac leo. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras venenatis, mi ac pretium congue, metus ante venenatis ex, at auctor velit urna eget neque. Sed fermentum purus nec felis elementum, mollis euismod enim posuere. Cras eget tortor magna. Sed molestie quam lacus, et molestie purus iaculis at. Nam sit amet velit est.

Proin ipsum libero, porttitor vitae eleifend quis, eleifend at sem. Phasellus suscipit vulputate tempor. Phasellus pretium leo ut nulla porttitor, et tempor tellus dictum. Cras consequat sollicitudin viverra. Pellentesque ut nibh gravida, sollicitudin dolor nec, pharetra odio. Sed eget blandit nulla, quis varius."
				},
				new Chapter
				{
					Title = "Глава 2", Text = "Топ контент второй главы"
				},
			};
			
			#endregion
			
			return new Lecture
			{
				Title = "Лекция 1",
				Order = 1,
				Chapters = chapters,
				Questions = questions 
			};
		}
		
		private static Lecture Lecture2()
		{
			#region Вопросы
			var questions = new List<Question>
			{
				new Question
				{
					Text = "Вопрос 1",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				new Question
				{
					Text = "Вопрос 2",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				new Question
				{
					Text = "Вопрос 3",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				new Question
				{
					Text = "Вопрос 4",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = true },
					}
				},
				new Question
				{
					Text = "Вопрос 5",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				}
				// new Question()
			};
			#endregion

			#region Главы
			
			var chapters = new List<Chapter>
			{
				new Chapter
				{
					Title = "Глава 1", Text = @"orem ipsum dolor sit amet, consectetur adipiscing elit. Sed feugiat sapien at velit fermentum, eu malesuada nibh condimentum. Etiam maximus a dolor eu pharetra. Aenean mollis nisl nec massa dictum volutpat. Sed mollis sollicitudin mi ac finibus. Sed pulvinar ligula sed finibus aliquet. Maecenas vestibulum libero nisi, sit amet tincidunt nisl scelerisque ut. Nulla vulputate sapien urna. Cras vulputate eros ullamcorper ipsum lacinia hendrerit. Mauris suscipit porta dui vitae semper.

Suspendisse eu molestie libero, sit amet faucibus purus. In tincidunt, ex quis dictum elementum, ligula sem ornare elit, ut vulputate velit mi vel nulla. Mauris volutpat, erat id rhoncus sagittis, odio nisl iaculis nisi, nec elementum nisl felis sed mauris. Praesent a purus ut felis pulvinar congue ut sed lectus. Integer tincidunt volutpat velit at bibendum. Ut a velit malesuada, viverra augue vel, volutpat diam. In dignissim non dui ut egestas. Integer eleifend hendrerit neque ac ultrices. Quisque vestibulum sem eget condimentum volutpat. Nulla suscipit sapien iaculis mollis dictum. Sed sodales nisi sed justo volutpat posuere. Duis porttitor, tortor sit amet dignissim consequat, felis metus rutrum nulla, ultrices ultricies felis metus et nulla. Suspendisse non efficitur nibh, ut consequat lacus. Duis eget pretium lectus. Aliquam erat volutpat. Integer placerat lectus vel justo mattis, in dignissim nunc tincidunt.

Sed vel odio cursus, ullamcorper arcu eu, vestibulum velit. Duis laoreet congue venenatis. Nunc non sem vel urna fermentum vehicula. Mauris commodo quam vel magna vulputate lacinia. Etiam sed luctus tellus. Pellentesque lobortis aliquet tortor sit amet dignissim. Nam elementum mauris ut scelerisque tincidunt. Vivamus lobortis dolor non odio volutpat, eget gravida felis dignissim. Phasellus congue massa sem, non feugiat nibh congue in. In tincidunt eros sed mauris facilisis dapibus. Mauris scelerisque ultrices magna, a vulputate leo tempus vel. Suspendisse pharetra arcu non velit hendrerit tempor. Mauris id leo mauris. Cras laoreet nulla massa, porttitor ornare lectus fermentum eget. Aenean sodales metus sem, vel imperdiet urna vulputate vel. Donec volutpat urna non mauris placerat, molestie efficitur libero fermentum.

Nulla lacinia finibus mattis. Pellentesque ullamcorper non ipsum nec imperdiet. Suspendisse lacinia magna in ornare dapibus. Mauris non congue lectus. Cras commodo id neque sed volutpat. Pellentesque faucibus in tellus a luctus. Maecenas porta hendrerit euismod. Aliquam tincidunt egestas consectetur.

Nunc bibendum viverra lorem, sit amet blandit enim finibus sit amet. Aenean semper ante hendrerit velit elementum facilisis. Mauris semper turpis ac condimentum consequat. Nullam id euismod lorem. Vivamus aliquet massa in mi aliquam elementum. Fusce luctus non odio et aliquam. Pellentesque erat ligula, aliquam id suscipit ut, vestibulum a erat. Nulla dignissim sapien eu nibh egestas ornare sed vel purus.

Nunc feugiat eget felis in faucibus. Morbi ullamcorper magna enim, at tempor nulla ornare id. Phasellus congue nec mauris tincidunt tincidunt. Quisque cursus aliquam ipsum, at ornare ante sollicitudin id. Nulla porta consectetur mattis. Nam laoreet, risus id pulvinar sagittis, ligula nisl posuere purus, vitae molestie dolor libero ut nunc. Etiam vulputate nibh a nisl vestibulum scelerisque. Sed in rutrum mauris, a malesuada lectus. Aliquam aliquam nisi ante, et fringilla mi vestibulum luctus. Nullam vitae turpis eget nulla pellentesque vehicula. Phasellus venenatis eros sed erat eleifend, id fringilla lectus pharetra. Vestibulum at lorem diam. Aenean ullamcorper non massa sollicitudin facilisis.

Ut non augue nisl. Cras blandit vel justo in condimentum. Proin ac malesuada velit, vel pharetra eros. Duis congue massa at gravida volutpat. Vestibulum leo tortor, fermentum non tempor placerat, eleifend at nisl. Vivamus in sem ac ipsum cursus malesuada. Aenean lobortis elementum sem eget posuere. Proin sit amet lectus placerat elit fermentum viverra. Cras malesuada dictum justo quis suscipit. Vestibulum vel consequat erat. Morbi quis nunc et erat lobortis sagittis. Phasellus efficitur metus eget velit dapibus malesuada nec at ipsum. Donec eu accumsan sem. Phasellus nec mi eget lacus lacinia commodo in eget ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus.

Duis quis ultrices ligula, at vestibulum libero. Suspendisse sollicitudin scelerisque nibh id gravida. Phasellus a vehicula justo, eget vestibulum eros. Nulla gravida aliquam eros ut aliquam. Nam tincidunt quam sed diam feugiat consequat. Duis vitae sem feugiat, interdum libero ut, tincidunt libero. Proin eu purus tempor, tempor nunc nec, fermentum ligula. Donec interdum lorem vitae nibh rhoncus, sit amet suscipit turpis facilisis. Praesent placerat orci nec est ultricies ultricies.

Phasellus a tincidunt justo. Praesent condimentum eleifend risus, quis tincidunt ex consequat vel. Aenean a est rutrum, semper orci quis, semper velit. Sed nec arcu massa. Aenean libero urna, cursus sed massa et, congue ornare dui. Nullam molestie metus tortor, vel lacinia massa tristique id. Nulla at quam lobortis sapien interdum vulputate. Suspendisse nec mattis erat. Aenean ipsum dui, faucibus vel iaculis ut, convallis sit amet erat. Ut lacinia mi nec convallis accumsan. Vivamus iaculis sapien eu neque ullamcorper pulvinar. Suspendisse et semper tortor. In tellus ligula, varius at viverra in, mollis sit amet odio. Vestibulum ut placerat risus, ut varius nisl. Sed et vehicula eros. Nullam tempor id ante ac condimentum.

Suspendisse sed magna neque. Nulla vel turpis massa. Curabitur rutrum rhoncus mi, eu eleifend turpis sollicitudin id. Sed non lacus quis erat consectetur scelerisque vitae eget lectus. Morbi quis mollis ligula, id porttitor quam. Nulla a varius diam. Interdum et malesuada fames ac ante ipsum primis in faucibus. Proin sit amet dui vel quam varius eleifend. Ut iaculis volutpat velit at blandit. Mauris pretium varius iaculis. Ut maximus ultrices libero. Sed nec orci eget felis fringilla ultricies sit amet a ipsum. Mauris id dui a est faucibus pharetra sit amet ut justo. Phasellus volutpat et nibh a fringilla. Duis diam dolor, posuere sit amet libero nec, lobortis porta magna.

Aenean mi nibh, posuere ut cursus dapibus, pulvinar gravida tellus. Praesent id vulputate lorem, ut sagittis augue. Vestibulum at malesuada nisi. Integer pulvinar aliquam tristique. Nam efficitur eleifend accumsan. Etiam et egestas tellus. Quisque nec velit eu ipsum viverra sodales feugiat nec lacus. Aliquam erat volutpat.

Nullam porta, turpis sit amet aliquam consectetur, felis velit rhoncus ligula, quis viverra tortor sapien eget ante. Donec commodo felis eget sem fringilla, sed posuere urna aliquet. Nulla pharetra placerat rhoncus. Maecenas non mi id sapien suscipit ornare at in augue. Donec ac magna tincidunt, tincidunt urna eget, mattis risus. Donec blandit quam id ante tincidunt, sed bibendum tortor lacinia. Aenean consectetur diam accumsan, auctor sapien sed, accumsan ipsum. Nullam vitae ligula non mi facilisis gravida eget a est. Nullam quis ligula id odio pellentesque congue sed porttitor purus. Maecenas fermentum eros in mauris varius varius. Donec viverra ultrices nisi, nec vulputate purus convallis id.

Maecenas eget libero hendrerit, fringilla massa vitae, fermentum neque. Praesent sed scelerisque nibh, eget condimentum nulla. Vivamus nec dui pharetra, congue enim et, ullamcorper metus. Phasellus egestas ultricies commodo. Aliquam lectus urna, dapibus non rhoncus non, iaculis vel turpis. Nulla vel tortor ex. Integer sed pellentesque dui, ac vulputate magna. Sed ac eleifend ligula. Donec iaculis, turpis feugiat imperdiet tincidunt, ex felis porttitor nulla, quis volutpat lorem purus sed nulla. Phasellus elit libero, aliquam vel risus non, faucibus mollis libero. Morbi tristique porttitor erat at sagittis. Cras commodo elementum lacinia.

Nam in efficitur dui, nec sollicitudin sem. Aliquam placerat odio vitae porta luctus. Quisque dapibus semper ante, sed accumsan nulla dignissim vel. Phasellus varius metus sed purus varius tincidunt. Vestibulum blandit ut lorem id viverra. Vivamus tristique neque sed leo dictum, ut gravida nisl semper. Vestibulum rutrum ultricies libero nec viverra. Aliquam ac ex gravida, eleifend metus id, lobortis purus.

Vestibulum nec vestibulum ex. Vestibulum vehicula magna porta sapien aliquam pretium. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Morbi suscipit ligula ex, eget tincidunt elit scelerisque fringilla. Praesent vel volutpat ante, in ornare odio. Duis vel felis commodo enim placerat gravida. Sed et scelerisque nulla. Quisque sit amet orci neque. Curabitur varius ex quis urna ullamcorper pretium vel eget urna. Praesent sodales metus nunc, varius semper augue molestie ac.

Nam pharetra neque leo, ut iaculis turpis cursus quis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Cras faucibus et turpis sit amet lobortis. Donec ut efficitur magna. Pellentesque eu orci a tellus efficitur vestibulum vel vel erat. Nunc ullamcorper pellentesque efficitur. Vestibulum augue sem, dictum a convallis nec, eleifend vitae massa.

Pellentesque vehicula felis nec ex malesuada efficitur. Quisque sapien nibh, mattis et tincidunt ut, pellentesque vel libero. Etiam dui justo, bibendum ut tortor vitae, finibus rutrum libero. Integer eleifend sollicitudin quam, quis suscipit ipsum posuere eu. Suspendisse nec dui quis nisl gravida hendrerit at ac leo. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras venenatis, mi ac pretium congue, metus ante venenatis ex, at auctor velit urna eget neque. Sed fermentum purus nec felis elementum, mollis euismod enim posuere. Cras eget tortor magna. Sed molestie quam lacus, et molestie purus iaculis at. Nam sit amet velit est.

Proin ipsum libero, porttitor vitae eleifend quis, eleifend at sem. Phasellus suscipit vulputate tempor. Phasellus pretium leo ut nulla porttitor, et tempor tellus dictum. Cras consequat sollicitudin viverra. Pellentesque ut nibh gravida, sollicitudin dolor nec, pharetra odio. Sed eget blandit nulla, quis varius."
				},
				new Chapter
				{
					Title = "Глава 2", Text = "Алекс топ контент. Тут текст лекции."
				},
				// new Chapter()
			};
			
			#endregion
			
			return new Lecture
			{
				Title = "Лекция 322",
				Order = 2,
				Chapters = chapters,
				Questions = questions 
			};
		}
	}
}